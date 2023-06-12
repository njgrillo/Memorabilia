namespace Memorabilia.Application.Features.Admin.ImageMaintenance;

public class ImageMaintenanceModel
{
    public ImageMaintenanceModel() { }

    public ImageMaintenanceModel(string memorabiliaImageRootPath, 
                                 string personImageRootPath, 
                                 IEnumerable<Entity.AutographImage> autographImages, 
                                 IEnumerable<Entity.MemorabiliaImage> memorabiliaImages, 
                                 IEnumerable<Entity.Person> people)
    {
        ExistingImageFileNames = autographImages.Select(image => image.FileName)
                                                .Distinct()
                                                .Union(memorabiliaImages.Select(image => image.FileName).Distinct())
                                                .Union(people.Select(image => image.ImageFileName).Distinct())
                                                .Distinct();

        IEnumerable<string> memImages = autographImages.Select(image => image.FileName)
                                                       .Distinct()
                                                       .Union(memorabiliaImages.Select(image => image.FileName).Distinct())
                                                       .Distinct();

        var orphanedMemImages = new List<string>();

        foreach (string file in memImages)
        {
            bool found = false;

            foreach (string directory in Directory.GetDirectories(memorabiliaImageRootPath))
            {
                if (File.Exists(Path.Combine(directory, file)))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                orphanedMemImages.Add(file);
            }            
        }

        List<string> personOrphanedImages = people.Select(image => image.ImageFileName)
                                                  .Distinct()
                                                  .Where(image => !File.Exists(Path.Combine(personImageRootPath, image)))
                                                  .ToList();

        OrphanedImageFileNames = personOrphanedImages.Union(orphanedMemImages).Distinct();
    }

    public IEnumerable<string> ExistingImageFileNames { get; set; } 
        = Enumerable.Empty<string>();

    public IEnumerable<string> OrphanedImageFileNames { get; set; } 
        = Enumerable.Empty<string>();
}

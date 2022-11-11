namespace Memorabilia.Application.Features.Admin.ImageMaintenance;

public class ImageMaintenanceViewModel
{
    public ImageMaintenanceViewModel() { }

    public ImageMaintenanceViewModel(string memorabiliaImageRootPath, 
                                     string personImageRootPath, 
                                     IEnumerable<Domain.Entities.AutographImage> autographImages, 
                                     IEnumerable<Domain.Entities.MemorabiliaImage> memorabiliaImages, 
                                     IEnumerable<Domain.Entities.Person> people)
    {
        ExistingImageFileNames = autographImages.Select(image => image.FileName)
                                                .Distinct()
                                                .Union(memorabiliaImages.Select(image => image.FileName).Distinct())
                                                .Union(people.Select(image => image.ImageFileName).Distinct())
                                                .Distinct();

        var memImages = autographImages.Select(image => image.FileName)
                                                .Distinct()
                                                .Union(memorabiliaImages.Select(image => image.FileName).Distinct())
                                                .Distinct();
        var orphanedMemImages = new List<string>();

        foreach (var file in memImages)
        {
            var found = false;

            foreach (var directory in Directory.GetDirectories(memorabiliaImageRootPath))
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

        var personOrphanedImages = people.Select(image => image.ImageFileName).Distinct().Where(image => !File.Exists(Path.Combine(personImageRootPath, image))).ToList();

        OrphanedImageFileNames = personOrphanedImages.Union(orphanedMemImages).Distinct();
    }

    public IEnumerable<string> ExistingImageFileNames { get; set; } = Enumerable.Empty<string>();

    public IEnumerable<string> OrphanedImageFileNames { get; set; } = Enumerable.Empty<string>();
}

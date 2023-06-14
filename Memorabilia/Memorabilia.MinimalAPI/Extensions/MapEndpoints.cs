namespace Memorabilia.MinimalAPI.Extensions;

public static class MapEndpoints
{
    public static void MapDomainEndpoints(this WebApplication app)
    {
        app.MediateGet<AccomplishmentTypeRequest>("accomplishmentType/{id}");
        app.MediateGet<AccomplishmentTypesRequest>("accomplishmentTypes");
        app.MediateGet<AcquisitionTypeRequest>("acquisitionType/{id}");
        app.MediateGet<AcquisitionTypesRequest>("acquisitionTypes");
    }
}

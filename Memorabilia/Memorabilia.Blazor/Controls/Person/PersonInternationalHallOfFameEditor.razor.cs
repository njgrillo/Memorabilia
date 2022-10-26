﻿#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonInternationalHallOfFameEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonInternationalHallOfFameViewModel> InternationalHallOfFames { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditInternationalHallOfFameType = true;
    private bool _canUpdate;
    private SavePersonInternationalHallOfFameViewModel _viewModel = new();

    private void Add()
    {
        InternationalHallOfFames.Add(_viewModel);

        _viewModel = new SavePersonInternationalHallOfFameViewModel();
    }

    private void Edit(SavePersonInternationalHallOfFameViewModel hallOfFame)
    {
        _viewModel.InternationalHallOfFameTypeId = hallOfFame.InternationalHallOfFameTypeId;
        _viewModel.Year = hallOfFame.Year;

        _canAdd = false;
        _canEditInternationalHallOfFameType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var hallOfFame = InternationalHallOfFames.Single(hof => hof.InternationalHallOfFameTypeId == _viewModel.InternationalHallOfFameTypeId);

        hallOfFame.InternationalHallOfFameTypeId = _viewModel.InternationalHallOfFameTypeId;
        hallOfFame.Year = _viewModel.Year;

        _viewModel = new SavePersonInternationalHallOfFameViewModel();

        _canAdd = true;
        _canEditInternationalHallOfFameType = true;
        _canUpdate = false;
    }
}

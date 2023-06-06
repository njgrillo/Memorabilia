﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonSingleSeasonRecordViewModel : EditModel
{
    public SavePersonSingleSeasonRecordViewModel() { }

    public SavePersonSingleSeasonRecordViewModel(SingleSeasonRecord record)
    {
        Id = record.Id;
        PersonId = record.PersonId;
        Record = record.Record;
        RecordType = Constant.RecordType.Find(record.RecordTypeId);
        Year = record.Year;
    }   

    public int PersonId { get; set; }

    public string Record { get; set; }

    public Constant.RecordType RecordType { get; set; }

    public string RecordTypeName => RecordType?.Name;

    [Required]
    [Range(1800, 3000, ErrorMessage = "Year is required and must be 1800 or greater.")]
    public int? Year { get; set; }
}

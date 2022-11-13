﻿global using Framework.Library.Extension;
global using Framework.Library.Handler;
global using Framework.Library.Web;
global using MediatR;
global using Memorabilia.Application.Features;
global using Memorabilia.Application.Features.Admin;
global using Memorabilia.Application.Features.Admin.AccomplishmentTypes;
global using Memorabilia.Application.Features.Admin.AcquisitionTypes;
global using Memorabilia.Application.Features.Admin.AuthenticationCompanies;
global using Memorabilia.Application.Features.Admin.AwardTypes;
global using Memorabilia.Application.Features.Admin.BammerTypes;
global using Memorabilia.Application.Features.Admin.BaseballTypes;
global using Memorabilia.Application.Features.Admin.BasketballTypes;
global using Memorabilia.Application.Features.Admin.BatTypes;
global using Memorabilia.Application.Features.Admin.Brands;
global using Memorabilia.Application.Features.Admin.ChampionTypes;
global using Memorabilia.Application.Features.Admin.Colleges;
global using Memorabilia.Application.Features.Admin.Colors;
global using Memorabilia.Application.Features.Admin.Commissioners;
global using Memorabilia.Application.Features.Admin.Conditions;
global using Memorabilia.Application.Features.Admin.Conferences;
global using Memorabilia.Application.Features.Admin.DashboardItems;
global using Memorabilia.Application.Features.Admin.Divisions;
global using Memorabilia.Application.Features.Admin.FigureSpecialtyTypes;
global using Memorabilia.Application.Features.Admin.FigureTypes;
global using Memorabilia.Application.Features.Admin.FootballTypes;
global using Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;
global using Memorabilia.Application.Features.Admin.Franchises;
global using Memorabilia.Application.Features.Admin.GameStyleTypes;
global using Memorabilia.Application.Features.Admin.GloveTypes;
global using Memorabilia.Application.Features.Admin.HelmetFinishes;
global using Memorabilia.Application.Features.Admin.HelmetQualityTypes;
global using Memorabilia.Application.Features.Admin.HelmetTypes;
global using Memorabilia.Application.Features.Admin.ImageMaintenance;
global using Memorabilia.Application.Features.Admin.ImageTypes;
global using Memorabilia.Application.Features.Admin.InscriptionTypes;
global using Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;
global using Memorabilia.Application.Features.Admin.ItemTypeBrand;
global using Memorabilia.Application.Features.Admin.ItemTypeGameStyle;
global using Memorabilia.Application.Features.Admin.ItemTypeLevel;
global using Memorabilia.Application.Features.Admin.ItemTypes;
global using Memorabilia.Application.Features.Admin.ItemTypeSizes;
global using Memorabilia.Application.Features.Admin.ItemTypeSports;
global using Memorabilia.Application.Features.Admin.ItemTypeSpots;
global using Memorabilia.Application.Features.Admin.JerseyQualityTypes;
global using Memorabilia.Application.Features.Admin.JerseyStyleTypes;
global using Memorabilia.Application.Features.Admin.JerseyTypes;
global using Memorabilia.Application.Features.Admin.LeaderTypes;
global using Memorabilia.Application.Features.Admin.Leagues;
global using Memorabilia.Application.Features.Admin.LevelTypes;
global using Memorabilia.Application.Features.Admin.MagazineTypes;
global using Memorabilia.Application.Features.Admin.Occupations;
global using Memorabilia.Application.Features.Admin.Orientations;
global using Memorabilia.Application.Features.Admin.People;
global using Memorabilia.Application.Features.Admin.Pewters;
global using Memorabilia.Application.Features.Admin.PhotoTypes;
global using Memorabilia.Application.Features.Admin.PriorityTypes;
global using Memorabilia.Application.Features.Admin.PrivacyTypes;
global using Memorabilia.Application.Features.Admin.ProjectTypes;
global using Memorabilia.Application.Features.Admin.PurchaseTypes;
global using Memorabilia.Application.Features.Admin.RecordTypes;
global using Memorabilia.Application.Features.Admin.Sizes;
global using Memorabilia.Application.Features.Admin.SportLeagueLevels;
global using Memorabilia.Application.Features.Admin.Sports;
global using Memorabilia.Application.Features.Admin.Spots;
global using Memorabilia.Application.Features.Admin.TeamRoleTypes;
global using Memorabilia.Application.Features.Admin.Teams;
global using Memorabilia.Application.Features.Admin.WritingInstruments;
global using Memorabilia.Application.Features.Autograph;
global using Memorabilia.Application.Features.Autograph.Authentication;
global using Memorabilia.Application.Features.Autograph.Image;
global using Memorabilia.Application.Features.Autograph.Inscriptions;
global using Memorabilia.Application.Features.Autograph.Spot;
global using Memorabilia.Application.Features.Image;
global using Memorabilia.Application.Features.Memorabilia;
global using Memorabilia.Application.Features.Memorabilia.Bammer;
global using Memorabilia.Application.Features.Memorabilia.Baseball;
global using Memorabilia.Application.Features.Memorabilia.Basketball;
global using Memorabilia.Application.Features.Memorabilia.Bat;
global using Memorabilia.Application.Features.Memorabilia.Bobblehead;
global using Memorabilia.Application.Features.Memorabilia.Book;
global using Memorabilia.Application.Features.Memorabilia.Bookplate;
global using Memorabilia.Application.Features.Memorabilia.Canvas;
global using Memorabilia.Application.Features.Memorabilia.Card;
global using Memorabilia.Application.Features.Memorabilia.CerealBox;
global using Memorabilia.Application.Features.Memorabilia.CompactDisc;
global using Memorabilia.Application.Features.Memorabilia.Document;
global using Memorabilia.Application.Features.Memorabilia.Drum;
global using Memorabilia.Application.Features.Memorabilia.Figure;
global using Memorabilia.Application.Features.Memorabilia.FirstDayCover;
global using Memorabilia.Application.Features.Memorabilia.Football;
global using Memorabilia.Application.Features.Memorabilia.Glove;
global using Memorabilia.Application.Features.Memorabilia.Golfball;
global using Memorabilia.Application.Features.Memorabilia.Guitar;
global using Memorabilia.Application.Features.Memorabilia.Hat;
global using Memorabilia.Application.Features.Memorabilia.HeadBand;
global using Memorabilia.Application.Features.Memorabilia.Helmet;
global using Memorabilia.Application.Features.Memorabilia.HockeyStick;
global using Memorabilia.Application.Features.Memorabilia.Image;
global using Memorabilia.Application.Features.Memorabilia.IndexCard;
global using Memorabilia.Application.Features.Memorabilia.Jersey;
global using Memorabilia.Application.Features.Memorabilia.JerseyNumber;
global using Memorabilia.Application.Features.Memorabilia.Lithograph;
global using Memorabilia.Application.Features.Memorabilia.Magazine;
global using Memorabilia.Application.Features.Memorabilia.Painting;
global using Memorabilia.Application.Features.Memorabilia.Pants;
global using Memorabilia.Application.Features.Memorabilia.Photo;
global using Memorabilia.Application.Features.Memorabilia.PinFlag;
global using Memorabilia.Application.Features.Memorabilia.PlayingCard;
global using Memorabilia.Application.Features.Memorabilia.Poster;
global using Memorabilia.Application.Features.Memorabilia.Puck;
global using Memorabilia.Application.Features.Memorabilia.Pylon;
global using Memorabilia.Application.Features.Memorabilia.Shirt;
global using Memorabilia.Application.Features.Memorabilia.Shoe;
global using Memorabilia.Application.Features.Memorabilia.Soccerball;
global using Memorabilia.Application.Features.Memorabilia.Tennisball;
global using Memorabilia.Application.Features.Memorabilia.TennisRacket;
global using Memorabilia.Application.Features.Memorabilia.Ticket;
global using Memorabilia.Application.Features.Memorabilia.Trunks;
global using Memorabilia.Application.Features.Memorabilia.WristBand;
global using Memorabilia.Application.Features.Project;
global using Memorabilia.Application.Features.Services.Filters;
global using Memorabilia.Application.Features.Services.Filters.Autographs;
global using Memorabilia.Application.Features.Services.Filters.Memorabilia;
global using Memorabilia.Application.Features.Services.Gallery.Memorabilia;
global using Memorabilia.Application.Features.Services.Tools.Profile;
global using Memorabilia.Application.Features.Tools.Profile;
global using Memorabilia.Application.Features.Tools.Profile.Baseball;
global using Memorabilia.Application.Features.Tools.Shared;
global using Memorabilia.Application.Features.Tools.Shared.Accomplishments;
global using Memorabilia.Application.Features.Tools.Shared.AllStars;
global using Memorabilia.Application.Features.Tools.Shared.Awards;
global using Memorabilia.Application.Features.Tools.Shared.CareerRecords;
global using Memorabilia.Application.Features.Tools.Shared.Champions;
global using Memorabilia.Application.Features.Tools.Shared.Colleges;
global using Memorabilia.Application.Features.Tools.Shared.Drafts;
global using Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;
global using Memorabilia.Application.Features.Tools.Shared.HallOfFamers;
global using Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;
global using Memorabilia.Application.Features.Tools.Shared.Leaders;
global using Memorabilia.Application.Features.Tools.Shared.Players;
global using Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;
global using Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;
global using Memorabilia.Application.Features.User;
global using Memorabilia.Application.Features.User.Dashboard;
global using Memorabilia.Application.Features.User.Login;
global using Memorabilia.Application.Features.User.Register;
global using Memorabilia.Application.Features.User.Settings;
global using Memorabilia.Blazor.Controls;
global using Memorabilia.Blazor.Controls.Dialogs;
global using Memorabilia.Blazor.Pages.Admin;
global using Memorabilia.Domain;
global using Memorabilia.Domain.Constants;
global using Memorabilia.Domain.Extensions;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.Extensions.Logging;
global using MudBlazor;
global using System.ComponentModel;
global using System.Data;
global using System.Globalization;

global using Color = MudBlazor.Color;

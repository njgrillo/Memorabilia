﻿global using Autofac;
global using FluentValidation;
global using Framework.Library.Domain.Command;
global using Framework.Library.Domain.Paging;
global using Framework.Library.Extension;
global using Framework.Library.Handler;
global using Framework.Library.Web;
global using MediatR;
global using Memorabilia.Application.Extensions;
global using Memorabilia.Application.Features;
global using Memorabilia.Application.Features.Admin.Commissioners;
global using Memorabilia.Application.Features.Admin.Conferences;
global using Memorabilia.Application.Features.Admin.DashboardItems;
global using Memorabilia.Application.Features.Admin.Divisions;
global using Memorabilia.Application.Features.Admin.Franchises;
global using Memorabilia.Application.Features.Admin.ItemTypeBrand;
global using Memorabilia.Application.Features.Admin.ItemTypeGameStyle;
global using Memorabilia.Application.Features.Admin.ItemTypeLevel;
global using Memorabilia.Application.Features.Admin.ItemTypeSizes;
global using Memorabilia.Application.Features.Admin.ItemTypeSports;
global using Memorabilia.Application.Features.Admin.ItemTypeSpots;
global using Memorabilia.Application.Features.Admin.LeaguePresidents;
global using Memorabilia.Application.Features.Admin.Leagues;
global using Memorabilia.Application.Features.Admin.People;
global using Memorabilia.Application.Features.Admin.Pewters;    
global using Memorabilia.Application.Features.Admin.Positions;    
global using Memorabilia.Application.Features.Admin.SportLeagueLevels;    
global using Memorabilia.Application.Features.Admin.Sports;    
global using Memorabilia.Application.Features.Admin.Teams;
global using Memorabilia.Application.Features.Autograph;
global using Memorabilia.Application.Features.Autograph.Authentication; 
global using Memorabilia.Application.Features.Autograph.Gallery; 
global using Memorabilia.Application.Features.Autograph.Inscriptions;
global using Memorabilia.Application.Features.Autograph.Inscriptions.Suggested;
global using Memorabilia.Application.Features.Autograph.Spot;
global using Memorabilia.Application.Features.Collection;
global using Memorabilia.Application.Features.Dashboard;
global using Memorabilia.Application.Features.Image;
global using Memorabilia.Application.Features.Memorabilia;
global using Memorabilia.Application.Features.Memorabilia.Bammer;
global using Memorabilia.Application.Features.Memorabilia.Baseball;
global using Memorabilia.Application.Features.Memorabilia.Basketball;
global using Memorabilia.Application.Features.Memorabilia.Bat;
global using Memorabilia.Application.Features.Memorabilia.Bobblehead;
global using Memorabilia.Application.Features.Memorabilia.Book;
global using Memorabilia.Application.Features.Memorabilia.Canvas;
global using Memorabilia.Application.Features.Memorabilia.Card;
global using Memorabilia.Application.Features.Memorabilia.CerealBox;
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
global using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments;
global using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards;
global using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;
global using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;
global using Memorabilia.Application.Features.Services.Filters;
global using Memorabilia.Application.Features.Services.Filters.Autographs;
global using Memorabilia.Application.Features.Services.Filters.Autographs.Rules;
global using Memorabilia.Application.Features.Services.Filters.Memorabilia;
global using Memorabilia.Application.Features.Services.Filters.Memorabilia.Rules;
global using Memorabilia.Application.Features.Services.Gallery.Memorabilia;
global using Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;
global using Memorabilia.Application.Features.Services.Interfaces;
global using Memorabilia.Application.Features.Services.Tools.Profile;
global using Memorabilia.Application.Features.Services.Tools.Profile.Rules;
global using Memorabilia.Application.Features.Tools.Profile.Common;
global using Memorabilia.Application.Features.User;
global using Memorabilia.Application.Features.User.Dashboard;
global using Memorabilia.Application.Features.User.Register;
global using Memorabilia.Domain;
global using Memorabilia.Domain.Extensions;
global using Memorabilia.Domain.SearchModels.Memorabilia;
global using Memorabilia.Repository.Interfaces;
global using System;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
global using System.Data;
global using System.Globalization;
global using System.IO;
global using System.Linq;
global using System.Linq.Expressions;
global using System.Text;
global using System.Threading.Tasks;
global using Constant = Memorabilia.Domain.Constants;
global using Enum = Memorabilia.Domain.Enums;
global using Entity = Memorabilia.Domain.Entities;

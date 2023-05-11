﻿global using Autofac;
global using Autofac.Extensions.DependencyInjection;
global using Framework.Library.Extension;
global using Framework.Library.Web;
global using MediatR;
global using MediatR.Courier;
global using MediatR.Courier.DependencyInjection;
global using Memorabilia.Application.Configuration;
global using Memorabilia.Application.Features.Admin;
global using Memorabilia.Application.Features.Admin.Commissioners;
global using Memorabilia.Application.Features.Services.Autographs.Inscriptions;
global using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments;
global using Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards;
global using Memorabilia.Application.Notifications;
global using Memorabilia.Application.Validators.Admin;
global using Memorabilia.Application.Validators.Admin.People;
global using Memorabilia.Application.Validators.Autograph;
global using Memorabilia.Application.Validators.Memorabilia;
global using Memorabilia.Application.Validators.Memorabilia.Bammer;
global using Memorabilia.Application.Validators.Memorabilia.Baseball;
global using Memorabilia.Application.Validators.Memorabilia.Basketball;
global using Memorabilia.Application.Validators.Memorabilia.Bat;
global using Memorabilia.Application.Validators.Memorabilia.Bobblehead;
global using Memorabilia.Application.Validators.Memorabilia.Book;
global using Memorabilia.Application.Validators.Memorabilia.Canvas;
global using Memorabilia.Application.Validators.Memorabilia.Card;
global using Memorabilia.Application.Validators.Memorabilia.CerealBox;
global using Memorabilia.Application.Validators.Memorabilia.Document;
global using Memorabilia.Application.Validators.Memorabilia.Drum;
global using Memorabilia.Application.Validators.Memorabilia.Figure;
global using Memorabilia.Application.Validators.Memorabilia.FirstDayCover;
global using Memorabilia.Application.Validators.Memorabilia.Football;
global using Memorabilia.Application.Validators.Memorabilia.Glove;
global using Memorabilia.Application.Validators.Memorabilia.Golfball;
global using Memorabilia.Application.Validators.Memorabilia.Guitar;
global using Memorabilia.Application.Validators.Memorabilia.Hat;
global using Memorabilia.Application.Validators.Memorabilia.HeadBand;
global using Memorabilia.Application.Validators.Memorabilia.Helmet;
global using Memorabilia.Application.Validators.Memorabilia.HockeyStick;
global using Memorabilia.Application.Validators.Memorabilia.IndexCard;
global using Memorabilia.Application.Validators.Memorabilia.Jersey;
global using Memorabilia.Application.Validators.Memorabilia.JerseyNumber;
global using Memorabilia.Application.Validators.Memorabilia.Lithograph;
global using Memorabilia.Application.Validators.Memorabilia.Magazine;
global using Memorabilia.Application.Validators.Memorabilia.Painting;
global using Memorabilia.Application.Validators.Memorabilia.Pant;
global using Memorabilia.Application.Validators.Memorabilia.Photo;
global using Memorabilia.Application.Validators.Memorabilia.PinFlag;
global using Memorabilia.Application.Validators.Memorabilia.PlayingCard;
global using Memorabilia.Application.Validators.Memorabilia.Poster;
global using Memorabilia.Application.Validators.Memorabilia.Puck;
global using Memorabilia.Application.Validators.Memorabilia.Pylon;
global using Memorabilia.Application.Validators.Memorabilia.Shirt;
global using Memorabilia.Application.Validators.Memorabilia.Shoe;
global using Memorabilia.Application.Validators.Memorabilia.Soccerball;
global using Memorabilia.Application.Validators.Memorabilia.Tennisball;
global using Memorabilia.Application.Validators.Memorabilia.TennisRacket;
global using Memorabilia.Application.Validators.Memorabilia.Ticket;
global using Memorabilia.Application.Validators.Memorabilia.Trunk;
global using Memorabilia.Application.Validators.Memorabilia.WristBand;
global using Memorabilia.Blazor;
global using Memorabilia.Blazor.Controls.Dialogs;
global using Memorabilia.Blazor.Controls.Errors;
global using Memorabilia.Blazor.Pages;
global using Memorabilia.Domain.Constants;
global using Memorabilia.Repository;
global using Memorabilia.Repository.Cache;
global using Memorabilia.Repository.Configuration;
global using Memorabilia.Repository.Implementations;
global using Memorabilia.Repository.Interfaces;
global using Memorabilia.Web.Extensions;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.DataProtection;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.RazorPages;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using MudBlazor;
global using MudBlazor.Services;
global using System;
global using System.Collections.Generic;
global using System.Diagnostics;
global using System.IO;
global using System.Linq;
global using System.Threading.Tasks;
using Codere.Contexto;
using Codere.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;


namespace Codere.Services
{
    public class TvMazeService : ITvMazeService
    {
        private readonly IContextoDB _context;
        private readonly HttpClient _httpClient;

        public TvMazeService(IContextoDB context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task FetchAndStoreShowsAsync()
        {
            var response = await _httpClient.GetAsync("https://api.tvmaze.com/shows");
            if (response.IsSuccessStatusCode)
            {
                var shows = JsonConvert.DeserializeObject<List<ShowMapeo>>(await response.Content.ReadAsStringAsync());
                foreach (var show in shows)
                {
                    var existingShow = await _context.Shows.FindAsync(show.Id);
                    if (existingShow == null)
                    {
                        await GuardarShow(show);
                    }
                    else
                    {
                        await ActualizarShow (show);
                    }
                }
                await _context.SaveChangesAsync(true);
            }
        }

        private async Task GuardarShow(ShowMapeo show)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Show nuevoShow = new Show();
                    nuevoShow.Id = show.Id;
                    nuevoShow.Url = show.Url;
                    nuevoShow.Name = show.Name;
                    nuevoShow.Type = show.Type;
                    nuevoShow.Language = show.Language;
                    nuevoShow.Genres = string.Join(", ", show.Genres);
                    nuevoShow.Status = show.Status;
                    nuevoShow.Runtime = show.Runtime;
                    nuevoShow.AverageRuntime = show.AverageRuntime;
                    if (show.Premiered != null) nuevoShow.Premiered = show.Premiered;
                    else nuevoShow.Premiered = null;
                    if (show.Ended != null) nuevoShow.Ended = show.Ended;
                    else nuevoShow.Ended = null;
                    nuevoShow.OfficialSite = show.OfficialSite;
                    nuevoShow.Weight = show.Weight;
                    nuevoShow.Summary = show.Summary;
                    nuevoShow.Updated = show.Updated;
                    _context.Shows.Add(nuevoShow);
                    await _context.SaveChangesAsync(true);

                    if(show.Schedule != null)
                    {
                        Schedule schedule = new Schedule();
                        schedule.Show_Id = nuevoShow.IdKey;
                        schedule.Time = show.Schedule.Time;
                        schedule.Day = string.Join(", ", show.Schedule.Day);

                        _context.Schedules.Add(schedule);
                        await _context.SaveChangesAsync(true);
                    }
                    
                    if(show.Rating  != null)
                    {
                        Rating rating = new Rating();
                        rating.Average = show.Rating.Average;
                        rating.Show_Id = nuevoShow.IdKey;

                        _context.Ratings.Add(rating);
                        await _context.SaveChangesAsync(true);
                    }

                    if(show.WebChannel != null)
                    {
                        WebChannel webChannel = new WebChannel();
                        webChannel.Id = show.WebChannel.Id;
                        webChannel.Show_Id = nuevoShow.IdKey;
                        webChannel.Name = show.WebChannel.Name;
                        webChannel.Country_Id = show.WebChannel.Id;
                        webChannel.OfficialSite = show.WebChannel.OfficialSite;

                        _context.WebChannels.Add(webChannel);
                        await _context.SaveChangesAsync(true);

                        if (show.WebChannel.Country != null)
                        {
                            Country country = new Country();
                            country.IdPadre = "W" + show.WebChannel.Id.ToString();
                            country.Name = show.WebChannel.Country.Name;
                            country.Code = show.WebChannel.Country.Code;
                            country.TimeZone = show.WebChannel.Country.TimeZone;

                            _context.Countries.Add(country);
                            await _context.SaveChangesAsync(true);
                        }
                    }

                    if (show.DvdCountry != null) {
                        DvdCountry dvdCountry = new DvdCountry();
                        dvdCountry.Show_Id = nuevoShow.IdKey;
                        dvdCountry.Name = show.DvdCountry.Name;
                        dvdCountry.Code = show.DvdCountry.Code;
                        dvdCountry.TimeZone = show.DvdCountry.TimeZone;

                        _context.DvdCountries.Add(dvdCountry);
                        await _context.SaveChangesAsync(true);
                    }

                    if (show.Externals != null)
                    {
                        External external = new External();
                        external.Show_Id = nuevoShow.IdKey;
                        external.Tvrage = show.Externals.Tvrage;
                        external.Thetvdb = show.Externals.Thetvdb;
                        external.Imdb = show.Externals.Imdb;

                        _context.Externals.Add(external);
                        await _context.SaveChangesAsync(true);
                    }

                    if (show.Image != null)
                    {
                        Image image = new Image();
                        image.Show_Id = nuevoShow.IdKey;
                        image.Medium = show.Image.Medium;
                        image.Original = show.Image.Original;

                        _context.Images.Add(image);
                        await _context.SaveChangesAsync(true);
                    }
                    

                    if(show.Link != null)
                    {
                        Link link = new Link();
                        link.Show_Id = nuevoShow.IdKey;
                        link.Self_Href = show.Link.Self_Href;

                        _context.Links.Add(link);
                        await _context.SaveChangesAsync(true);
                    }

                    if (show.PreviousEpisode != null)
                    {
                        PreviousEpisode episode = new PreviousEpisode();
                        episode.Show_Id = nuevoShow.IdKey;
                        episode.Href = show.PreviousEpisode.Href;
                        episode.Name = show.PreviousEpisode.Name;

                        _context.PreviousEpisodes.Add(episode);
                        await _context.SaveChangesAsync(true);
                    }

                    if (show.Network != null) 
                    {
                        Network network = new Network();
                        network.Id = show.Network.Id;
                        network.Show_Id = nuevoShow.IdKey;
                        network.Name = show.Network.Name;
                        network.OfficialSite = show.Network.OfficialSite;

                        _context.Networks.Add(network);
                        await _context.SaveChangesAsync(true);

                        if (show.Network.Country != null)
                        {
                            Country country = new Country();
                            country.IdPadre = "N" + show.Network.Id.ToString();
                            country.Name = show.Network.Country.Name;
                            country.Code = show.Network.Country.Code;
                            country.TimeZone = show.Network.Country.TimeZone;

                            _context.Countries.Add(country);
                            await _context.SaveChangesAsync(true);
                        }
                    }
                    
                    // Confirma la transacción
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Si hay un error, revertir todos los cambios
                    await transaction.RollbackAsync();

                    // Manejar la excepción según sea necesario
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private async Task ActualizarShow(ShowMapeo show)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Buscar el show existente
                    var existingShow = await _context.Shows.FindAsync(show.Id);
                    if (existingShow != null)
                    {
                        existingShow.Url = show.Url;
                        existingShow.Name = show.Name;
                        existingShow.Type = show.Type;
                        existingShow.Language = show.Language;
                        existingShow.Genres = string.Join(", ", show.Genres);
                        existingShow.Status = show.Status;
                        existingShow.Runtime = show.Runtime;
                        existingShow.AverageRuntime = show.AverageRuntime;
                        existingShow.Premiered = show.Premiered;
                        if(show.Ended != null) existingShow.Ended = show.Ended;
                        existingShow.OfficialSite = show.OfficialSite;
                        existingShow.Weight = show.Weight;
                        existingShow.Summary = show.Summary;
                        existingShow.Updated = show.Updated;

                        _context.Shows.Update(existingShow);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar Schedule
                    var existingSchedule = await _context.Schedules.FirstOrDefaultAsync(s => s.Show_Id == show.Id);
                    if (existingSchedule != null)
                    {
                        existingSchedule.Time = show.Schedule.Time;
                        existingSchedule.Day = string.Join(", ", show.Schedule.Day);

                        _context.Schedules.Update(existingSchedule);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar Rating
                    var existingRating = await _context.Ratings.FirstOrDefaultAsync(r => r.Show_Id == show.Id);
                    if (existingRating != null)
                    {
                        existingRating.Average = show.Rating.Average;

                        _context.Ratings.Update(existingRating);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar WebChannel
                    if (show.WebChannel != null)
                    {
                        if (show.WebChannel.Country != null)
                        {
                            var existingCountry = await _context.Countries.FirstOrDefaultAsync(c => c.IdPadre == "W" + show.WebChannel.Id.ToString());
                            if (existingCountry != null)
                            {
                                existingCountry.Name = show.WebChannel.Country.Name;
                                existingCountry.Code = show.WebChannel.Country.Code;
                                existingCountry.TimeZone = show.WebChannel.Country.TimeZone;

                                _context.Countries.Update(existingCountry);
                                await _context.SaveChangesAsync(true);
                            }
                        }

                        var existingWebChannel = await _context.WebChannels.FindAsync(show.WebChannel.Id);
                        if (existingWebChannel != null)
                        {
                            existingWebChannel.Name = show.WebChannel.Name;
                            existingWebChannel.Country_Id = show.WebChannel.Id;
                            existingWebChannel.OfficialSite = show.WebChannel.OfficialSite;

                            _context.WebChannels.Update(existingWebChannel);
                            await _context.SaveChangesAsync(true);
                        }
                    }

                    // Actualizar DvdCountry
                    if (show.DvdCountry != null)
                    {
                        var existingDvdCountry = await _context.DvdCountries.FirstOrDefaultAsync(dc => dc.Show_Id == show.Id);
                        if (existingDvdCountry != null)
                        {
                            existingDvdCountry.Name = show.DvdCountry.Name;
                            existingDvdCountry.Code = show.DvdCountry.Code;
                            existingDvdCountry.TimeZone = show.DvdCountry.TimeZone;

                            _context.DvdCountries.Update(existingDvdCountry);
                            await _context.SaveChangesAsync(true);
                        }
                    }

                    // Actualizar External
                    var existingExternal = await _context.Externals.FirstOrDefaultAsync(e => e.Show_Id == show.Id);
                    if (existingExternal != null)
                    {
                        existingExternal.Tvrage = show.Externals.Tvrage;
                        existingExternal.Thetvdb = show.Externals.Thetvdb;
                        existingExternal.Imdb = show.Externals.Imdb;

                        _context.Externals.Update(existingExternal);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar Image
                    var existingImage = await _context.Images.FirstOrDefaultAsync(i => i.Show_Id == show.Id);
                    if (existingImage != null)
                    {
                        existingImage.Medium = show.Image.Medium;
                        existingImage.Original = show.Image.Original;

                        _context.Images.Update(existingImage);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar Link
                    var existingLink = await _context.Links.FirstOrDefaultAsync(l => l.Show_Id == show.Id);
                    if (existingLink != null)
                    {
                        existingLink.Self_Href = show.Link.Self_Href;

                        _context.Links.Update(existingLink);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar PreviousEpisode
                    var existingEpisode = await _context.PreviousEpisodes.FirstOrDefaultAsync(e => e.Show_Id == show.Id);
                    if (existingEpisode != null)
                    {
                        existingEpisode.Href = show.PreviousEpisode.Href;
                        existingEpisode.Name = show.PreviousEpisode.Name;

                        _context.PreviousEpisodes.Update(existingEpisode);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar Network
                    var existingNetwork = await _context.Networks.FindAsync(show.Network.Id);
                    if (existingNetwork != null)
                    {
                        existingNetwork.Show_Id = show.Id;
                        existingNetwork.Name = show.Network.Name;
                        existingNetwork.OfficialSite = show.Network.OfficialSite;

                        _context.Networks.Update(existingNetwork);
                        await _context.SaveChangesAsync(true);
                    }

                    // Actualizar Country para Network
                    if (show.Network.Country != null)
                    {
                        var existingCountry = await _context.Countries.FirstOrDefaultAsync(c => c.IdPadre == "N" + show.Network.Id.ToString());
                        if (existingCountry != null)
                        {
                            existingCountry.Name = show.Network.Country.Name;
                            existingCountry.Code = show.Network.Country.Code;
                            existingCountry.TimeZone = show.Network.Country.TimeZone;

                            _context.Countries.Update(existingCountry);
                            await _context.SaveChangesAsync(true);
                        }
                    }

                    // Confirma la transacción
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Si hay un error, revertir todos los cambios
                    await transaction.RollbackAsync();

                    // Manejar la excepción según sea necesario
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public async Task<List<dynamic>> ObtenerShow()
        {
            // return await _context.Shows.ToListAsync();

            //return await _context.Shows.Include(s => s.WebChannel) // Carga WebChannel
            //    .Include(s => s.Schedule) // Carga Schedule
            //    .Include(s => s.Network) // Carga Network
            //    .Include(s => s.External) // Carga External
            //    .Include(s => s.Image) // Carga Image
            //    .Include(s => s.Link) // Carga Link
            //    .Include(s => s.DvdCountry) // Carga DvdCountry
            //    .Include(s => s.PreviousEpisode) // Carga PreviousEpisode
            //    .Include(s => s.Rating).ToListAsync(); // Carga Rating

            var result = await _context.Shows
                .Select(show => new
                {
                    show.Id,
                    show.Name,
                    show.Url,
                    show.Language,
                    show.Genres,
                    show.Status,
                    show.Runtime,
                    show.AverageRuntime,
                    show.Premiered,
                    show.Ended,
                    show.OfficialSite,
                    show.Weight,
                    show.Summary,
                    show.Updated,
                    show.Rating_Average,
                    WebChannel = show.WebChannel != null ? new
                    {
                        show.WebChannel.Name,
                        show.WebChannel.OfficialSite
                    } : null,
                    Schedule = show.Schedule != null ? new
                    {
                        show.Schedule.Time,
                        show.Schedule.Day
                    } : null,
                    Network = show.Network != null ? new
                    {
                        show.Network.Name,
                        show.Network.OfficialSite,
                        Country = show.Network.Country != null ? new
                        {
                            show.Network.Country.Name,
                            show.Network.Country.Code,
                            show.Network.Country.TimeZone
                        } : null
                    } : null,
                    External = show.External != null ? new
                    {
                        show.External.Tvrage,
                        show.External.Thetvdb,
                        show.External.Imdb
                    } : null,
                    Image = show.Image != null ? new
                    {
                        show.Image.Medium,
                        show.Image.Original
                    } : null,
                    Link = show.Link != null ? new
                    {
                        show.Link.Self_Href,
                        show.Link.Previousepisode_Href,
                        show.Link.Previousepisode_Name
                    } : null,
                    DvdCountry = show.DvdCountry != null ? new
                    {
                        show.DvdCountry.Name,
                        show.DvdCountry.Code,
                        show.DvdCountry.TimeZone
                    } : null,
                    PreviousEpisode = show.PreviousEpisode != null ? new
                    {
                        show.PreviousEpisode.Href,
                        show.PreviousEpisode.Name
                    } : null,
                    Rating = show.Rating != null ? new
                    {
                        show.Rating.Average
                    } : null
                })
                .ToListAsync();

            var dynamicResult = result.Select(item => (dynamic)item).ToList();
            return dynamicResult;
        }
    }
}

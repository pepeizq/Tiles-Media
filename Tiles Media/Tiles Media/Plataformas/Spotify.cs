using CommunityToolkit.WinUI.UI.Controls;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using SpotifyAPI.Web;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI;
using static Tiles_Media.MainWindow;

namespace Plataformas
{
    public static class Spotify
    {
        public static void Cargar()
        {
            Objetos.cbSpotifyTipoBuscar.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbSpotifyTipoBuscar.PointerExited += Animaciones.SaleRatonComboCaja2;

            Objetos.botonSpotifyBuscar.Click += BuscarClick;
            Objetos.botonSpotifyBuscar.PointerEntered += Animaciones.EntraRatonBoton2; 
            Objetos.botonSpotifyBuscar.PointerExited += Animaciones.SaleRatonBoton2;

            Objetos.tbSpotifyBuscar.KeyDown += BuscarPulsar;

            Objetos.cbOpcionesSpotifyModo.SelectionChanged += CambiarModoEjecucion;
            Objetos.cbOpcionesSpotifyModo.PointerEntered += Animaciones.EntraRatonComboCaja2;
            Objetos.cbOpcionesSpotifyModo.PointerExited += Animaciones.SaleRatonComboCaja2;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;

            if (datos.Values["OpcionesSpotifyModo"] != null)
            {
                if ((int)datos.Values["OpcionesSpotifyModo"] == -1)
                {
                    Objetos.cbOpcionesSpotifyModo.SelectedIndex = 0;
                }
                else
                {
                    Objetos.cbOpcionesSpotifyModo.SelectedIndex = (int)datos.Values["OpcionesSpotifyModo"];
                }
            }
            else
            {
                Objetos.cbOpcionesSpotifyModo.SelectedIndex = 0;
            }

            Objetos.botonOpcionesSpotifyAbrirAyuda.Click += AbrirAyudaClick;
            Objetos.botonOpcionesSpotifyAbrirAyuda.PointerEntered += Animaciones.EntraRatonBoton2;
            Objetos.botonOpcionesSpotifyAbrirAyuda.PointerExited += Animaciones.SaleRatonBoton2;

            if (datos.Values["OpcionesSpotifyClienteID"] == null)
            {
                Objetos.tbOpcionesSpotifyClienteID.Text = null;
            }
            else
            {
                Objetos.tbOpcionesSpotifyClienteID.Text = datos.Values["OpcionesSpotifyClienteID"].ToString();
            }
            
            Objetos.tbOpcionesSpotifyClienteID.TextChanged += DetectarClienteID;

            if (datos.Values["OpcionesSpotifyClienteSecreto"] == null)
            {
                Objetos.tbOpcionesSpotifyClienteSecreto.Text = null;
            }
            else
            {
                Objetos.tbOpcionesSpotifyClienteSecreto.Text = datos.Values["OpcionesSpotifyClienteSecreto"].ToString();
            }

            Objetos.tbOpcionesSpotifyClienteSecreto.TextChanged += DetectarClienteSecreto;

            Objetos.botonSpotifyIrOpciones.Click += AbrirOpcionesClick;
            Objetos.botonSpotifyIrOpciones.PointerEntered += Animaciones.EntraRatonBoton2;
            Objetos.botonSpotifyIrOpciones.PointerExited += Animaciones.SaleRatonBoton2;

            ComprobarConexionOpciones();
        }

        private static void CambiarModoEjecucion(object sender, SelectionChangedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesSpotifyModo"] = Objetos.cbOpcionesSpotifyModo.SelectedIndex;
        }

        private static async void AbrirAyudaClick(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            ImageEx imagen = new ImageEx
            {
                Source = "Assets\\Ayuda\\spotify.png",
                IsCacheEnabled = true,
                EnableLazyLoading = true,
                CornerRadius = new CornerRadius(5),
                Width = 880,
                Height = 573
            };

            ContentDialog ventana = new ContentDialog
            {
                RequestedTheme = ElementTheme.Dark,
                SecondaryButtonText = recursos.GetString("SpotifyOptionsOpenLink"),
                CloseButtonText = recursos.GetString("Close"),
                Content = imagen,
                XamlRoot = Objetos.ventana.Content.XamlRoot
            };

            ventana.SecondaryButtonClick += AbrirEnlace;

            await ventana.ShowAsync();
        }

        private static async void AbrirEnlace(ContentDialog ventana, ContentDialogButtonClickEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://developer.spotify.com/dashboard/applications"));
        }

        private static void AbrirOpcionesClick(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pestañas.Visibilidad(Objetos.gridOpciones, true, null, false);
            BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
            ScrollViewers.EnseñarSubir(Objetos.svOpciones);
        }

        private static void DetectarClienteID(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Length > 0) 
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["OpcionesSpotifyClienteID"] = tb.Text;
                ComprobarConexionOpciones();
            }
        }

        private static void DetectarClienteSecreto(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim().Length > 0)
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["OpcionesSpotifyClienteSecreto"] = tb.Text;
                ComprobarConexionOpciones();
            }
        }

        private static async void ComprobarConexionOpciones()
        {
            if (Objetos.tbOpcionesSpotifyClienteID.Text.Trim().Length > 0 && Objetos.tbOpcionesSpotifyClienteSecreto.Text.Trim().Length > 0)
            {
                ActivarDesactivar(false);

                SpotifyClient cliente = await ComprobarConexion();

                if (cliente != null) 
                {
                    Objetos.gridSpotifyBuscador.Visibility = Visibility.Visible;
                    Objetos.gridSpotifyMensajeOpciones.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Objetos.gridSpotifyBuscador.Visibility = Visibility.Collapsed;
                    Objetos.gridSpotifyMensajeOpciones.Visibility = Visibility.Visible;
                }

                ActivarDesactivar(true);
            }
        }

        private static async Task<SpotifyClient> ComprobarConexion()
        {
            try
            {
                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                SpotifyClientConfig config = SpotifyClientConfig.CreateDefault();

                ClientCredentialsRequest request = new ClientCredentialsRequest(datos.Values["OpcionesSpotifyClienteID"].ToString(), datos.Values["OpcionesSpotifyClienteSecreto"].ToString());
                ClientCredentialsTokenResponse response = await new OAuthClient(config).RequestToken(request);

                SpotifyClient cliente = new SpotifyClient(config.WithToken(response.AccessToken));
                return cliente;
            }
            catch { }

            return null;
        }

        private static void BuscarClick(object sender, RoutedEventArgs e)
        {
            Buscar();
        }

        private static void BuscarPulsar(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                Buscar();
            }
        }

        private static async void Buscar()
        {
            if (Objetos.tbSpotifyBuscar.Text.Trim().Length > 3)
            {
                ActivarDesactivar(false);
                Objetos.prSpotifyResultados.Visibility = Visibility.Visible;

                SpotifyClient cliente = await ComprobarConexion();

                if (cliente != null) 
                {
                    if (Objetos.cbSpotifyTipoBuscar.SelectedIndex == 0)
                    {
                        SearchRequest busqueda = new SearchRequest(SearchRequest.Types.Album, Objetos.tbSpotifyBuscar.Text.Trim())
                        {
                            Limit = 50
                        };

                        SearchResponse resultados = await cliente.Search.Item(busqueda);

                        Objetos.gvSpotifyResultados.Items.Clear();

                        foreach (SimpleAlbum album in resultados.Albums.Items)
                        {
                            Objetos.gvSpotifyResultados.Items.Add(GenerarItem(album.Images[0].Url, album.Name, album));
                        }
                    }
                    else if (Objetos.cbSpotifyTipoBuscar.SelectedIndex == 1)
                    {
                        SearchRequest busqueda = new SearchRequest(SearchRequest.Types.Playlist, Objetos.tbSpotifyBuscar.Text.Trim())
                        {
                            Limit = 50
                        };

                        SearchResponse resultados = await cliente.Search.Item(busqueda);

                        Objetos.gvSpotifyResultados.Items.Clear();

                        foreach (SimplePlaylist plist in resultados.Playlists.Items)
                        {
                            Objetos.gvSpotifyResultados.Items.Add(GenerarItem(plist.Images[0].Url, plist.Name, plist));
                        }
                    }
                    else if (Objetos.cbSpotifyTipoBuscar.SelectedIndex == 2)
                    {
                        SearchRequest busqueda = new SearchRequest(SearchRequest.Types.Artist, Objetos.tbSpotifyBuscar.Text.Trim())
                        {
                            Limit = 50
                        };

                        SearchResponse resultados = await cliente.Search.Item(busqueda);

                        Objetos.gvSpotifyResultados.Items.Clear();

                        foreach (FullArtist pista in resultados.Artists.Items)
                        {
                            Objetos.gvSpotifyResultados.Items.Add(GenerarItem(pista.Images[0].Url, pista.Name, pista));
                        }
                    }
                }

                ActivarDesactivar(true);
                Objetos.prSpotifyResultados.Visibility = Visibility.Collapsed;
            }
        }

        private static GridViewItem GenerarItem(string imagenEnlace, string nombre, object tag)
        {
            ImageEx imagen = new ImageEx
            {
                IsCacheEnabled = true,
                EnableLazyLoading = true,
                Stretch = Stretch.UniformToFill,
                Source = imagenEnlace,
                CornerRadius = new CornerRadius(2)
            };

            Button2 botonItem = new Button2
            {
                Content = imagen,
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]),
                BorderThickness = new Thickness(2),
                Tag = tag,
                MaxWidth = 300,
                CornerRadius = new CornerRadius(5)
            };

            botonItem.Click += ImagenItemClick;
            botonItem.PointerEntered += Animaciones.EntraRatonBoton2;
            botonItem.PointerExited += Animaciones.SaleRatonBoton2;

            TextBlock tbTt = new TextBlock
            {
                Text = nombre
            };

            ToolTipService.SetToolTip(botonItem, tbTt);
            ToolTipService.SetPlacement(botonItem, PlacementMode.Bottom);

            GridViewItem item = new GridViewItem
            {
                Content = botonItem,
                Margin = new Thickness(5, 0, 5, 10)
            };

            return item;
        }

        private static void ImagenItemClick(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            Button boton = sender as Button;
            Random azar = new Random();

            if (boton.Tag.GetType() == typeof(SimpleAlbum))
            {
                SimpleAlbum album = boton.Tag as SimpleAlbum;

                string enlace = album.Uri;

                if ((int)datos.Values["OpcionesSpotifyModo"] == 0)
                {
                    enlace = enlace.Replace("spotify:album:", "https://open.spotify.com/album/");
                } 

                Tiles.PrecargarMedia(album.Name,
                        enlace, "spotify" + azar.Next(10000).ToString(),
                        album.Images[0].Url,
                        album.Images[1].Url);
            }
            else if (boton.Tag.GetType() == typeof(SimplePlaylist))
            {
                SimplePlaylist plist = boton.Tag as SimplePlaylist;

                string enlace = plist.Uri;

                if ((int)datos.Values["OpcionesSpotifyModo"] == 0)
                {
                    enlace = enlace.Replace("spotify:playlist:", "https://open.spotify.com/playlist/");
                }

                Tiles.PrecargarMedia(plist.Name,
                        enlace, "spotify" + azar.Next(10000).ToString(),
                        plist.Images[0].Url,
                        plist.Images[1].Url);
            }
            else if (boton.Tag.GetType() == typeof(FullArtist))
            {
                FullArtist artista = boton.Tag as FullArtist;

                string enlace = artista.Uri;

                if ((int)datos.Values["OpcionesSpotifyModo"] == 0)
                {
                    enlace = enlace.Replace("spotify:artist:", "https://open.spotify.com/artist/");
                }

                Tiles.PrecargarMedia(artista.Name,
                        enlace, "spotify" + azar.Next(10000).ToString(),
                        artista.Images[0].Url,
                        artista.Images[1].Url);
            }
        }

        private static void ActivarDesactivar(bool estado)
        {
            Objetos.cbSpotifyTipoBuscar.IsEnabled = estado;
            Objetos.botonSpotifyBuscar.IsEnabled = estado;
            Objetos.cbOpcionesSpotifyModo.IsEnabled = estado;
            Objetos.tbSpotifyBuscar.IsEnabled = estado;
            Objetos.tbOpcionesSpotifyClienteID.IsEnabled = estado;
            Objetos.tbOpcionesSpotifyClienteSecreto.IsEnabled = estado;
        }
    }
}

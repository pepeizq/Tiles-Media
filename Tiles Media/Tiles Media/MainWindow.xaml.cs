using CommunityToolkit.WinUI.UI.Controls;
using FontAwesome6.Fonts;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Plataformas;

namespace Tiles_Media
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            CargarObjetos();

            BarraTitulo.Generar(this);
            BarraTitulo.CambiarTitulo(null);
            Cerrar.Cargar();
            Pesta�as.Cargar();
            ScrollViewers.Cargar();
            Interfaz.Menu.Cargar();

            Netflix.Cargar();
            DisneyPlus.Cargar();
            PrimeVideo.Cargar();
            Spotify.Cargar();

            Tiles.Cargar();
            Opciones.CargarDatos();

            Pesta�as.Visibilidad(gridPresentacion, true, null, false);
        }

        public void CargarObjetos()
        {
            Objetos.ventana = ventana;
            Objetos.gridTitulo = gridTitulo;
            Objetos.tbTitulo = tbTitulo;
            Objetos.nvPrincipal = nvPrincipal;
            Objetos.nvItemMenu = nvItemMenu;
            Objetos.menuItemMenu = menuItemMenu;
            Objetos.nvItemOpciones = nvItemOpciones;
            Objetos.nvItemSubirArriba = nvItemSubirArriba;
            Objetos.gridCierre = gridCierre;

            //-------------------------------------------------------------------

            Objetos.botonCerrarAppSi = botonCerrarAppSi;
            Objetos.botonCerrarAppNo = botonCerrarAppNo;
            Objetos.iconoCerrarAppAzar = iconoCerrarAppAzar;
            Objetos.tbCerrarAppAzar = tbCerrarAppAzar;
            Objetos.botonCerrarAppAzar = botonCerrarAppAzar;

            //-------------------------------------------------------------------

            Objetos.gridPresentacion = gridPresentacion;
            Objetos.gridNetflix = gridNetflix;
            Objetos.gridDisneyPlus = gridDisneyPlus;
            Objetos.gridPrimeVideo = gridPrimeVideo;
            Objetos.gridSpotify = gridSpotify;
            Objetos.gridTilesPrecarga = gridTilesPrecarga;
            Objetos.gridOpciones = gridOpciones;

            //-------------------------------------------------------------------

            Objetos.svPresentacion = svPresentacion;
            Objetos.gvPresentacionPlataformas = gvPresentacionPlataformas;

            //-------------------------------------------------------------------

            Objetos.botonNetflixBuscar = botonNetflixBuscar;
            Objetos.tbNetflixBuscar = tbNetflixBuscar;
            Objetos.svNetflixResultados = svNetflixResultados;
            Objetos.prNetflixResultados = prNetflixResultados;
            Objetos.gvNetflixResultados = gvNetflixResultados;
            Objetos.ttNetflixErrorBuscar = ttNetflixErrorBuscar;
            Objetos.cbOpcionesNetflixModo = cbOpcionesNetflixModo;
            Objetos.botonOpcionesNetflixAPIAyuda = botonOpcionesNetflixAPIAyuda;
            Objetos.tbOpcionesNetflixAPIID = tbOpcionesNetflixAPIID;
            Objetos.tbOpcionesNetflixSearchID = tbOpcionesNetflixSearchID;

            //-------------------------------------------------------------------

            Objetos.botonDisneyPlusBuscar = botonDisneyPlusBuscar;
            Objetos.tbDisneyPlusBuscar = tbDisneyPlusBuscar;
            Objetos.svDisneyPlusResultados = svDisneyPlusResultados;
            Objetos.prDisneyPlusResultados = prDisneyPlusResultados;
            Objetos.gvDisneyPlusResultados = gvDisneyPlusResultados;
            Objetos.ttDisneyPlusErrorBuscar = ttDisneyPlusErrorBuscar;
            Objetos.botonOpcionesDisneyPlusAPIAyuda = botonOpcionesDisneyPlusAPIAyuda;
            Objetos.tbOpcionesDisneyPlusAPIID = tbOpcionesDisneyPlusAPIID;
            Objetos.tbOpcionesDisneyPlusSearchID = tbOpcionesDisneyPlusSearchID;

            //-------------------------------------------------------------------

            Objetos.botonPrimeVideoBuscar = botonPrimeVideoBuscar;
            Objetos.tbPrimeVideoBuscar = tbPrimeVideoBuscar;
            Objetos.svPrimeVideoResultados = svPrimeVideoResultados;
            Objetos.prPrimeVideoResultados = prPrimeVideoResultados;
            Objetos.gvPrimeVideoResultados = gvPrimeVideoResultados;
            Objetos.cbOpcionesPrimeVideoModo = cbOpcionesPrimeVideoModo;

            //-------------------------------------------------------------------

            Objetos.gridSpotifyBuscador = gridSpotifyBuscador;
            Objetos.cbSpotifyTipoBuscar = cbSpotifyTipoBuscar;
            Objetos.botonSpotifyBuscar = botonSpotifyBuscar;
            Objetos.tbSpotifyBuscar = tbSpotifyBuscar;
            Objetos.svSpotifyResultados = svSpotifyResultados;
            Objetos.prSpotifyResultados = prSpotifyResultados;
            Objetos.gvSpotifyResultados = gvSpotifyResultados;
            Objetos.gridSpotifyMensajeOpciones = gridSpotifyMensajeOpciones;
            Objetos.botonSpotifyIrOpciones = botonSpotifyIrOpciones;
            Objetos.cbOpcionesSpotifyModo = cbOpcionesSpotifyModo;
            Objetos.botonOpcionesSpotifyAbrirAyuda = botonOpcionesSpotifyAbrirAyuda;
            Objetos.tbOpcionesSpotifyClienteID = tbOpcionesSpotifyClienteID;
            Objetos.tbOpcionesSpotifyClienteSecreto = tbOpcionesSpotifyClienteSecreto;

            //-------------------------------------------------------------------

            Objetos.spTilesBotones = spTilesBotones;
            Objetos.svTilesPrecarga = svTilesPrecarga;
            Objetos.spTilesPesta�as = spTilesPestanas;
            Objetos.iconoTilesPrecargaPeque�a = iconoTilesPrecargaPequena;
            Objetos.iconoTilesPrecargaMediana = iconoTilesPrecargaMediana;
            Objetos.iconoTilesPrecargaAncha = iconoTilesPrecargaAncha;
            Objetos.iconoTilesPrecargaGrande = iconoTilesPrecargaGrande;
            Objetos.tbTilesPrecargaTitulo = tbTilesPrecargaTitulo;
            Objetos.tbTilesPrecargaEjecutable = tbTilesPrecargaEjecutable;
            Objetos.tbTilesPrecargaImagenPeque�a = tbTilesPrecargaImagenPequena;
            Objetos.tbTilesPrecargaImagenMediana = tbTilesPrecargaImagenMediana;
            Objetos.tbTilesPrecargaImagenAncha = tbTilesPrecargaImagenAncha;
            Objetos.tbTilesPrecargaImagenGrande = tbTilesPrecargaImagenGrande;
            Objetos.gridTilesPrecargaImagenPeque�a = gridTilesPrecargaImagenPequena;
            Objetos.gridTilesPrecargaImagenMediana = gridTilesPrecargaImagenMediana;
            Objetos.gridTilesPrecargaImagenAncha = gridTilesPrecargaImagenAncha;
            Objetos.gridTilesPrecargaImagenGrande = gridTilesPrecargaImagenGrande;
            Objetos.imagenTilesPrecargaPeque�a = imagenTilesPrecargaPequena;
            Objetos.imagenTilesPrecargaMediana = imagenTilesPrecargaMediana;
            Objetos.imagenTilesPrecargaAncha = imagenTilesPrecargaAncha;
            Objetos.imagenTilesPrecargaGrande = imagenTilesPrecargaGrande;
            Objetos.imagenTilesPrecargaPeque�a2 = imagenTilesPrecargaPequena2;
            Objetos.imagenTilesPrecargaMediana2 = imagenTilesPrecargaMediana2;
            Objetos.imagenTilesPrecargaAncha2 = imagenTilesPrecargaAncha2;
            Objetos.imagenTilesPrecargaGrande2 = imagenTilesPrecargaGrande2;
            Objetos.cbTilesPrecargaPeque�aEstiramiento = cbTilesPrecargaPequenaEstiramiento;
            Objetos.cbTilesPrecargaMedianaEstiramiento = cbTilesPrecargaMedianaEstiramiento;
            Objetos.cbTilesPrecargaAnchaEstiramiento = cbTilesPrecargaAnchaEstiramiento;
            Objetos.cbTilesPrecargaGrandeEstiramiento = cbTilesPrecargaGrandeEstiramiento;
            Objetos.cbTilesPrecargaPeque�aOrientacionHorizontal = cbTilesPrecargaPequenaOrientacionHorizontal;
            Objetos.cbTilesPrecargaMedianaOrientacionHorizontal = cbTilesPrecargaMedianaOrientacionHorizontal;
            Objetos.cbTilesPrecargaAnchaOrientacionHorizontal = cbTilesPrecargaAnchaOrientacionHorizontal;
            Objetos.cbTilesPrecargaGrandeOrientacionHorizontal = cbTilesPrecargaGrandeOrientacionHorizontal;
            Objetos.cbTilesPrecargaPeque�aOrientacionVertical = cbTilesPrecargaPequenaOrientacionVertical;
            Objetos.cbTilesPrecargaMedianaOrientacionVertical = cbTilesPrecargaMedianaOrientacionVertical;
            Objetos.cbTilesPrecargaAnchaOrientacionVertical = cbTilesPrecargaAnchaOrientacionVertical;
            Objetos.cbTilesPrecargaGrandeOrientacionVertical = cbTilesPrecargaGrandeOrientacionVertical;
            Objetos.botonTilesCargarJuego = botonTilesCargarJuego;

            //-------------------------------------------------------------------

            Objetos.spOpcionesBotones = spOpcionesBotones;
            Objetos.svOpciones = svOpciones;
            Objetos.spOpcionesPesta�as = spOpcionesPestanas;
            Objetos.cbOpcionesIdioma = cbOpcionesIdioma;
            Objetos.cbOpcionesPantalla = cbOpcionesPantalla;
            Objetos.botonOpcionesLimpiar = botonOpcionesLimpiar;
        }

        public static class Objetos
        {
            public static Window ventana { get; set; }
            public static Grid gridTitulo { get; set; }
            public static TextBlock tbTitulo { get; set; }
            public static NavigationView nvPrincipal { get; set; }
            public static NavigationViewItem nvItemMenu { get; set; }
            public static MenuFlyout menuItemMenu { get; set; }
            public static NavigationViewItem nvItemOpciones { get; set; }
            public static NavigationViewItem nvItemSubirArriba { get; set; }
            public static Grid gridCierre { get; set; }

            //-------------------------------------------------------------------

            public static Button botonCerrarAppSi { get; set; }
            public static Button botonCerrarAppNo { get; set; }
            public static FontAwesome iconoCerrarAppAzar { get; set; }
            public static TextBlock tbCerrarAppAzar { get; set; }
            public static Button botonCerrarAppAzar { get; set; }

            //-------------------------------------------------------------------

            public static Grid gridPresentacion { get; set; }
            public static Grid gridNetflix { get; set; }
            public static Grid gridDisneyPlus { get; set; }
            public static Grid gridPrimeVideo { get; set; }
            public static Grid gridSpotify { get; set; }
            public static Grid gridTilesPrecarga { get; set; }
            public static Grid gridOpciones { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svPresentacion { get; set; }
            public static AdaptiveGridView gvPresentacionPlataformas { get; set; }

            //-------------------------------------------------------------------

            public static Button botonNetflixBuscar { get; set; }
            public static TextBox tbNetflixBuscar { get; set; }
            public static ScrollViewer svNetflixResultados { get; set; }
            public static ProgressRing prNetflixResultados { get; set; }
            public static AdaptiveGridView gvNetflixResultados { get; set; }
            public static TeachingTip ttNetflixErrorBuscar { get; set; }
            public static ComboBox cbOpcionesNetflixModo { get; set; }
            public static Button botonOpcionesNetflixAPIAyuda { get; set; }
            public static TextBox tbOpcionesNetflixAPIID { get; set; }
            public static TextBox tbOpcionesNetflixSearchID { get; set; }

            //-------------------------------------------------------------------
            public static Button botonDisneyPlusBuscar { get; set; }
            public static TextBox tbDisneyPlusBuscar { get; set; }
            public static ScrollViewer svDisneyPlusResultados { get; set; }
            public static ProgressRing prDisneyPlusResultados { get; set; }
            public static AdaptiveGridView gvDisneyPlusResultados { get; set; }
            public static TeachingTip ttDisneyPlusErrorBuscar { get; set; }
            public static Button botonOpcionesDisneyPlusAPIAyuda { get; set; }
            public static TextBox tbOpcionesDisneyPlusAPIID { get; set; }
            public static TextBox tbOpcionesDisneyPlusSearchID { get; set; }

            //-------------------------------------------------------------------

            public static Button botonPrimeVideoBuscar { get; set; }
            public static TextBox tbPrimeVideoBuscar { get; set; }
            public static ScrollViewer svPrimeVideoResultados { get; set; }
            public static ProgressRing prPrimeVideoResultados { get; set; }
            public static AdaptiveGridView gvPrimeVideoResultados { get; set; }
            public static ComboBox cbOpcionesPrimeVideoModo { get; set; }

            //-------------------------------------------------------------------

            public static Grid gridSpotifyBuscador { get; set; }
            public static ComboBox cbSpotifyTipoBuscar { get; set; }
            public static Button botonSpotifyBuscar { get; set; }
            public static TextBox tbSpotifyBuscar { get; set; }
            public static ScrollViewer svSpotifyResultados { get; set; }
            public static ProgressRing prSpotifyResultados { get; set; }
            public static AdaptiveGridView gvSpotifyResultados { get; set; }
            public static Grid gridSpotifyMensajeOpciones { get; set; }
            public static Button botonSpotifyIrOpciones { get; set; }
            public static ComboBox cbOpcionesSpotifyModo { get; set; }
            public static Button botonOpcionesSpotifyAbrirAyuda { get; set; }
            public static TextBox tbOpcionesSpotifyClienteID { get; set; }
            public static TextBox tbOpcionesSpotifyClienteSecreto { get; set; }

            //-------------------------------------------------------------------

            public static StackPanel spTilesBotones { get; set; }
            public static ScrollViewer svTilesPrecarga { get; set; }
            public static StackPanel spTilesPesta�as { get; set; }
            public static FontAwesome iconoTilesPrecargaPeque�a { get; set; }
            public static FontAwesome iconoTilesPrecargaMediana { get; set; }
            public static FontAwesome iconoTilesPrecargaAncha { get; set; }
            public static FontAwesome iconoTilesPrecargaGrande { get; set; }
            public static TextBox tbTilesPrecargaTitulo { get; set; }
            public static TextBox tbTilesPrecargaEjecutable { get; set; }
            public static TextBox tbTilesPrecargaImagenPeque�a { get; set; }
            public static TextBox tbTilesPrecargaImagenMediana { get; set; }
            public static TextBox tbTilesPrecargaImagenAncha { get; set; }
            public static TextBox tbTilesPrecargaImagenGrande { get; set; }
            public static Grid gridTilesPrecargaImagenPeque�a { get; set; }
            public static Grid gridTilesPrecargaImagenMediana { get; set; }
            public static Grid gridTilesPrecargaImagenAncha { get; set; }
            public static Grid gridTilesPrecargaImagenGrande { get; set; }
            public static Image imagenTilesPrecargaPeque�a { get; set; }
            public static Image imagenTilesPrecargaMediana { get; set; }
            public static Image imagenTilesPrecargaAncha { get; set; }
            public static Image imagenTilesPrecargaGrande { get; set; }
            public static Image imagenTilesPrecargaPeque�a2 { get; set; }
            public static Image imagenTilesPrecargaMediana2 { get; set; }
            public static Image imagenTilesPrecargaAncha2 { get; set; }
            public static Image imagenTilesPrecargaGrande2 { get; set; }
            public static ComboBox cbTilesPrecargaPeque�aEstiramiento { get; set; }
            public static ComboBox cbTilesPrecargaMedianaEstiramiento { get; set; }
            public static ComboBox cbTilesPrecargaAnchaEstiramiento { get; set; }
            public static ComboBox cbTilesPrecargaGrandeEstiramiento { get; set; }
            public static ComboBox cbTilesPrecargaPeque�aOrientacionHorizontal { get; set; }
            public static ComboBox cbTilesPrecargaMedianaOrientacionHorizontal { get; set; }
            public static ComboBox cbTilesPrecargaAnchaOrientacionHorizontal { get; set; }
            public static ComboBox cbTilesPrecargaGrandeOrientacionHorizontal { get; set; }
            public static ComboBox cbTilesPrecargaPeque�aOrientacionVertical { get; set; }
            public static ComboBox cbTilesPrecargaMedianaOrientacionVertical { get; set; }
            public static ComboBox cbTilesPrecargaAnchaOrientacionVertical { get; set; }
            public static ComboBox cbTilesPrecargaGrandeOrientacionVertical { get; set; }
            public static Button botonTilesCargarJuego { get; set; }

            //-------------------------------------------------------------------

            public static StackPanel spOpcionesBotones { get; set; }
            public static ScrollViewer svOpciones { get; set; }
            public static StackPanel spOpcionesPesta�as { get; set; }
            public static ComboBox cbOpcionesIdioma { get; set; }
            public static ComboBox cbOpcionesPantalla { get; set; }
            public static Button botonOpcionesLimpiar { get; set; }
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pesta�as.CreadorItems("/Assets/Plataformas/logo_cualquierstreaming.png", recursos.GetString("AnyMedia"));
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_spotify.png", "Spotify");
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_primevideo.png", "Prime Video");
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_disneyplus.png", "Disney Plus");
            Pesta�as.CreadorItems("/Assets/Plataformas/logo_netflix.png", "Netflix");

            //----------------------------------------------------------

            GridViewItem itemNetflix = Presentacion.CreadorBotones("/Assets/Plataformas/logo_netflix_completo.png", "Netflix", false, 25);
            Button2 botonNetflix = itemNetflix.Content as Button2;
            botonNetflix.Click += AbrirNetflixClick;
            Objetos.gvPresentacionPlataformas.Items.Add(itemNetflix);

            GridViewItem itemDisneyPlus = Presentacion.CreadorBotones("/Assets/Plataformas/logo_disneyplus.png", "Disney Plus", false, 10);
            Button2 botonDisneyPlus = itemDisneyPlus.Content as Button2;
            botonDisneyPlus.Click += AbrirDisneyPlusClick;
            Objetos.gvPresentacionPlataformas.Items.Add(itemDisneyPlus);

            GridViewItem itemPrimeVideo = Presentacion.CreadorBotones("/Assets/Plataformas/logo_primevideo_completo.png", "Prime Video", false, 20);
            Button2 botonPrimeVideo = itemPrimeVideo.Content as Button2;
            botonPrimeVideo.Click += AbrirPrimeVideoClick;
            Objetos.gvPresentacionPlataformas.Items.Add(itemPrimeVideo);

            GridViewItem itemSpotify = Presentacion.CreadorBotones("/Assets/Plataformas/logo_spotify_completo.png", "Spotify", false, 20);
            Button2 botonSpotify = itemSpotify.Content as Button2;
            botonSpotify.Click += AbrirSpotifyClick;
            Objetos.gvPresentacionPlataformas.Items.Add(itemSpotify);

            GridViewItem itemCualquierStreaming = Presentacion.CreadorBotones("/Assets/Plataformas/logo_cualquierstreaming.png", recursos.GetString("AnyMedia"), true, 20);
            Button2 botonCualquierStreaming = itemCualquierStreaming.Content as Button2;
            botonCualquierStreaming.Click += AbrirCualquierStreamingClick;
            Objetos.gvPresentacionPlataformas.Items.Add(itemCualquierStreaming);
        }

        private void nvPrincipal_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ResourceLoader recursos = new ResourceLoader();

            if (args.InvokedItemContainer != null)
            {
                if (args.InvokedItemContainer.GetType() == typeof(NavigationViewItem2))
                {
                    NavigationViewItem2 item = args.InvokedItemContainer as NavigationViewItem2;

                    if (item.Name == "nvItemMenu")
                    {

                    }
                    else if (item.Name == "nvItemOpciones")
                    {
                        Pesta�as.Visibilidad(gridOpciones, true, null, false);
                        BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
                        ScrollViewers.Ense�arSubir(svOpciones);
                    }
                }
            }

            if (args.InvokedItem != null)
            {
                if (args.InvokedItem.GetType() == typeof(StackPanel2))
                {
                    StackPanel2 sp = (StackPanel2)args.InvokedItem;

                    if (sp.Children[1] != null)
                    {
                        if (sp.Children[1].GetType() == typeof(TextBlock))
                        {
                            TextBlock tb = sp.Children[1] as TextBlock;

                            if (tb.Text == "Netflix")
                            {
                                Pesta�as.Visibilidad(gridNetflix, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svNetflixResultados);
                            }
                            else if (tb.Text == "Disney Plus")
                            {
                                Pesta�as.Visibilidad(gridDisneyPlus, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svDisneyPlusResultados);
                            }
                            else if (tb.Text == "Prime Video")
                            {
                                Pesta�as.Visibilidad(gridPrimeVideo, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svPrimeVideoResultados);
                            }
                            else if (tb.Text == "Spotify")
                            {
                                Pesta�as.Visibilidad(gridSpotify, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.Ense�arSubir(svSpotifyResultados);
                            }
                            else if (tb.Text == recursos.GetString("AnyMedia"))
                            {
                                Pesta�as.Visibilidad(gridTilesPrecarga, true, null, false);
                                BarraTitulo.CambiarTitulo(null);
                                Tiles.PrecargarMedia(null, null, null, null, null);
                            }
                        }
                    }
                }
            }
        }

        private void AbrirNetflixClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)Objetos.nvPrincipal.MenuItems[1];
            Pesta�as.Visibilidad(gridNetflix, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svNetflixResultados);
        }

        private void AbrirDisneyPlusClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)Objetos.nvPrincipal.MenuItems[2];
            Pesta�as.Visibilidad(gridDisneyPlus, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svDisneyPlusResultados);
        }

        private void AbrirPrimeVideoClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)Objetos.nvPrincipal.MenuItems[3];
            Pesta�as.Visibilidad(gridPrimeVideo, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svPrimeVideoResultados);
        }

        private void AbrirSpotifyClick(object sender, RoutedEventArgs e)
        {
            StackPanel sp = (StackPanel)Objetos.nvPrincipal.MenuItems[4];
            Pesta�as.Visibilidad(gridSpotify, true, sp, true);
            BarraTitulo.CambiarTitulo(null);
            ScrollViewers.Ense�arSubir(svSpotifyResultados);
        }

        private void AbrirCualquierStreamingClick(object sender, RoutedEventArgs e)
        {
            Pesta�as.Visibilidad(gridTilesPrecarga, true, null, false);
            BarraTitulo.CambiarTitulo(null);
            Tiles.PrecargarMedia(null, null, null, null, null);
        }
    }
}
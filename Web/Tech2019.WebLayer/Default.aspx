<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tech2019.WebLayer.Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Website Title -->
    <title>Tech2019 Ürün Takip Sayfası</title>

    <!-- Styles -->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,400i,600,700,700i&display=swap" rel="stylesheet">
    <link href="web/css/bootstrap.css" rel="stylesheet">
    <link href="web/css/fontawesome-all.css" rel="stylesheet">
    <link href="web/css/swiper.css" rel="stylesheet">
    <link href="web/css/magnific-popup.css" rel="stylesheet">
    <link href="web/css/styles.css" rel="stylesheet">

    <!-- Favicon  -->
    <link rel="icon" href="images/favicon.png">
</head>
<body data-spy="scroll" data-target=".fixed-top">

    <!-- Preloader -->
    <div class="spinner-wrapper">
        <div class="spinner">
            <div class="bounce1"></div>
            <div class="bounce2"></div>
            <div class="bounce3"></div>
        </div>
    </div>
    <!-- end of preloader -->

    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark navbar-custom fixed-top">

        <!-- Text Logo -->
        <a class="navbar-brand logo-text page-scroll" href="/default.aspx">Tech2019</a>

        <!-- Mobile Menu Toggle Button -->
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-awesome fas fa-bars"></span>
            <span class="navbar-toggler-awesome fas fa-times"></span>
        </button>
        <!-- end of mobile menu toggle button -->

        <div class="collapse navbar-collapse" id="navbarsExampleDefault">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <a class="nav-link page-scroll" href="/default.aspx">ANA SAYFA <span class="sr-only">(current)</span></a>
                </li>

                <!-- Dropdown Menu -->
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle page-scroll" href="#" id="navbarDropdown" role="button" aria-haspopup="true" aria-expanded="false">ÜRÜN İŞLEMLERİ</a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="#productTrace"><span class="item-text">ÜRÜN TAKİP</span></a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#products"><span class="item-text">ÜRÜNLER</span></a>
                    </div>
                </li>
                <!-- end of dropdown menu -->

                <li class="nav-item">
                    <a class="nav-link page-scroll" href="#description">HAKKIMIZDA</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link page-scroll" href="#contact">İLETİŞİM</a>
                </li>
            </ul>

        </div>
    </nav>
    <!-- end of navbar -->
    <!-- end of navigation -->

    <!-- Main -->
    <header class="header">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="text-container">
                        <div class="countdown">
                            <h3 style="color: whitesmoke">Kampanyanın Sona Ermesine Kalan Süre :</h3>
                            <span id="clock"></span>
                        </div>
                        <h1>Tech2019'a Hoş Geldiniz</h1>
                        <p class="p-large">Buradan satıştaki ürünlerimize göz atabilir, servise bıraktığınız ürünlerin seri numaraları ile takibini yapabilirsiniz.</p>
                        <a class="btn-outline-lg page-scroll" href="#productTrace">ÜRÜN TAKİP</a>
                        <a class="btn-solid-lg page-scroll" href="#products">ÜRÜNLER</a>
                    </div>
                    <!-- end of text-container -->
                </div>
                <!-- end of col -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container -->

        <!-- Image Slider -->
        <div class="outer-container">
            <div class="slider-container">
                <div class="swiper-container image-slider-1">
                    <div class="swiper-wrapper">

                        <!-- Slide -->
                        <div class="swiper-slide">
                            <img class="img-fluid" src="web/images/Nature.png" alt="alternative">
                        </div>
                        <!-- end of slide -->

                        <!-- Slide -->
                        <div class="swiper-slide">
                            <img class="img-fluid" src="web/images/Nature_2.png" alt="alternative">
                        </div>
                        <!-- end of slide -->

                        <!-- Slide -->
                        <div class="swiper-slide">
                            <img class="img-fluid" src="web/images/Nature_3.png" alt="alternative">
                        </div>
                        <!-- end of slide -->

                    </div>
                    <!-- end of swiper-wrapper -->

                    <!-- Add Arrows -->
                    <div class="swiper-button-next"></div>
                    <div class="swiper-button-prev"></div>
                    <!-- end of add arrows -->

                </div>
                <!-- end of swiper-container -->
            </div>
            <!-- end of slider-container -->
        </div>
        <!-- end of outer-container -->
        <!-- end of image slider -->

    </header>
    <!-- end of main -->
    <!-- end of main -->

    <!-- ProductTrace -->
    <div id="productTrace" class="form-1">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="text-container">
                        <h2>Servisteki Ürününüzü Takip Edin</h2>
                        <p>Size servis görevlimiz tarafindan verilen 5 haneli seri numarasını girin, ardından arama butonuna basın</p>
                        <ul class="list-unstyled li-space-lg">
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body"><strong>Ürünüz</strong> servisimizde güvendedir</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body"><strong>Yedek parçada</strong> orjinal kullanma sözümüz var</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body"><strong>Seri numaranız ile</strong> ürününüzün son durumunu detaylı olarak takip edebilirsiniz</div>
                            </li>
                        </ul>
                    </div>
                    <!-- end of text-container -->
                </div>
                <!-- end of col -->

                <!-- Product Trace Form -->

                <div class="col-lg-6">

                    <%-- TODO : 1 label 1 textbox 1 button ile ilgili ürünün seri numarası ile takip edilebileceği küçük bir groupbox yapılsın --%>
                </div>
                <!-- end of col -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container -->
    </div>
    <!-- end of form-1 -->
    <!-- end of productTrace -->

    <!-- Products -->
    <div id="products" class="basic-1">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <img class="img-fluid" src="web/images/Nature_1.png" alt="alternative">
                </div>
                <!-- end of col -->
                <div class="col-lg-6">
                    <div class="text-container">
                        <h2>Ürünlerimize Göz Atın</h2>

                        <table class="table table-bordered">
                            <tr>
                                <th>ÜRÜN ADI</th>
                                <th>MARKA</th>
                                <th>SATIŞ FİYATI</th>
                            </tr>
                            <tr>
                                <td>ürün1</td>
                                <td>marka1</td>
                                <td>123,33 ₺</td>
                            </tr>
                            <tr>
                                <td>ürün2</td>
                                <td>marka2</td>
                                <td>12369,33 ₺</td>
                            </tr>
                        </table>

                    </div>
                    <!-- end of text-container -->
                    <h6>Daha fazlasını mağazamızda bulabilirsiniz...</h6>
                </div>
                <!-- end of col -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container -->
    </div>
    <!-- end of basic-1 -->
    <!-- end of products -->

    <!-- Description -->
    <div id="description" class="form-1">
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-fluid" src="web/images/Nature_4.png" alt="alternative">
                </div>
                <div class="col-lg-8">
                    <div class="text-container">
                        <h2>Biz Kimiz?</h2>
                        <p>Çeşitli kategorilerde geniş ürün gamı ve uygun fiyatlarıyla hem müşterilerine ürün satan hem de sattığı ürünlerde yetkili servis faaliyetleri yürüten 118 yıllık bir firmayız.</p>
                        <ul class="list-unstyled li-space-lg">
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body"><strong>Neden biz?</strong> hem satın alma hem servis faaliyetlerini tek elden yürüttüğümüz için</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body"><strong>Yedek parçalar</strong> bizim firmamızda sadece ama sadece orjinal kullanılır</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-square"></i>
                                <div class="media-body"><strong>7/24</strong> kesintisiz hizmet, ürünler ve hizmetlerimiz hakkında detaylı bilgi</div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container -->
    </div>
    <!-- end of Description -->
    <!-- end of Description -->

    <!-- Partners -->
    <div class="slider-1">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <p class="p-small">MARKALARIMIZ</p>

                    <!-- Image Slider -->
                    <div class="slider-container">
                        <div class="swiper-container image-slider-2">
                            <div class="swiper-wrapper">
                                <div class="swiper-slide">
                                    <img class="img-fluid" src="web/images/customer-logo-1.png" alt="alternative">
                                </div>
                                <div class="swiper-slide">
                                    <img class="img-fluid" src="web/images/customer-logo-2.png" alt="alternative">
                                </div>
                                <div class="swiper-slide">
                                    <img class="img-fluid" src="web/images/customer-logo-3.png" alt="alternative">
                                </div>
                                <div class="swiper-slide">
                                    <img class="img-fluid" src="web/images/customer-logo-4.png" alt="alternative">
                                </div>
                                <div class="swiper-slide">
                                    <img class="img-fluid" src="web/images/customer-logo-5.png" alt="alternative">
                                </div>
                                <div class="swiper-slide">
                                    <img class="img-fluid" src="web/images/customer-logo-6.png" alt="alternative">
                                </div>
                            </div>
                            <!-- end of swiper-wrapper -->
                        </div>
                        <!-- end of swiper container -->
                    </div>
                    <!-- end of slider-container -->
                    <!-- end of image slider -->

                </div>
                <!-- end of col -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container -->
    </div>
    <!-- end of slider-1 -->
    <!-- end of partners -->

    <!-- Contact -->
    <div id="contact" class="form-3">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="text-container">
                        <h2>Contact Details</h2>
                        <p>For registration questions please get in touch using the contact details below. For any questions use the form.</p>
                        <h3>Main Office Location</h3>
                        <ul class="list-unstyled li-space-lg">
                            <li class="media">
                                <i class="fas fa-map-marker-alt"></i>
                                <div class="media-body">22 Innovative, San Francisco, CA 94043, US</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-mobile-alt"></i>
                                <div class="media-body">+44 68 554 332, &nbsp;&nbsp;<i class="fas fa-mobile-alt"></i>&nbsp; +44 31 276 112</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-envelope"></i>
                                <div class="media-body"><a class="light-gray" href="mailto:contact@zigo.com">contact@zigo.com</a> <i class="fas fa-globe"></i><a class="light-gray" href="#your-link">www.zigo.com</a></div>
                            </li>
                        </ul>
                    </div>
                    <!-- end of text-container -->
                </div>
                <!-- end of col -->
                <div class="col-lg-6">

                    <!-- Contact Form -->
                     <%-- TODO : Mesajlar bölümü ile birlikte tasarım ve işlevsel olarak benzer uygulamalar yapılacak --%>
                    <!-- end of contact form -->

                </div>
                <!-- end of col -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container -->
    </div>
    <!-- end of form-3 -->
    <!-- end of contact -->

    <!-- Scripts -->
    <script src="web/js/jquery.min.js"></script>
    <!-- jQuery for Bootstrap's JavaScript plugins -->
    <script src="web/js/popper.min.js"></script>
    <!-- Popper tooltip library for Bootstrap -->
    <script src="web/js/bootstrap.min.js"></script>
    <!-- Bootstrap framework -->
    <script src="web/js/jquery.easing.min.js"></script>
    <!-- jQuery Easing for smooth scrolling between anchors -->
    <script src="web/js/jquery.countdown.min.js"></script>
    <!-- The Final Countdown plugin for jQuery -->
    <script src="web/js/swiper.min.js"></script>
    <!-- Swiper for image and text sliders -->
    <script src="web/js/jquery.magnific-popup.js"></script>
    <!-- Magnific Popup for lightboxes -->
    <script src="web/js/validator.min.js"></script>
    <!-- Validator.js - Bootstrap plugin that validates forms -->
    <script src="web/js/scripts.js"></script>
    <!-- Custom scripts -->
</body>
</html>

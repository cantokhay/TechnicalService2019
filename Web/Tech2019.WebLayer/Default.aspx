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
                        <a class="dropdown-item" href="Tech2019.WebFormContent.aspx"><span class="item-text">ÜRÜN TAKİP</span></a>
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
                        <p class="p-large">Buradaki linkten satıştaki ürünlerimize göz atabilir, servise bıraktığınız ürünlerin seri numaraları ile takibini yapabilirsiniz.</p>
                        <a class="btn-outline-lg page-scroll" href="Tech2019.WebFormContent.aspx">ÜRÜN TAKİP</a>
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
                <!-- end of col-6 -->

                <div class="col-lg-6">
                    <img class="img-fluid" src="web/images/Nature_1.png" alt="alternative">
                </div>

                <!-- end of col-6 -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container -->
    </div>
    <!-- end of productTrace -->

    <!-- Products -->
    <div id="products" class="basic-1">
        <div class="container">
            <div class="row">
                <%--<div class="col-lg-6">
                    <img class="img-fluid" src="web/images/Nature_1.png" alt="alternative">
                </div>--%>
                <!-- end of col -->
                <div class="col-lg-12">
                    <div class="text-container">
                        <h2>Ürünlerimize Göz Atın</h2>

                        <table class="table table-bordered">
                            <tr>
                                <th>ÜRÜN ID</th>
                                <th>ÜRÜN ADI</th>
                                <th>MARKA</th>
                                <th>SATIŞ FİYATI</th>
                            </tr>

                            <asp:Repeater ID="ProductRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("ProductId") %></td>
                                        <td><%#Eval("ProductName") %></td>
                                        <td><%#Eval("ProductBrand") %></td>
                                        <td><%#Eval("ProductSalePrice") %> ₺</td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>

                    </div>
                    <!-- end of text-container -->
                    <h6>Daha fazlasını mağazamızda bulabilirsiniz...</h6>
                </div>
                <!-- end of col-6 -->
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
                        <h2>Bize Ulaşın</h2>
                        <p>Yandaki formu doldurarak bize düşüncelerini, önerilerinizi, sorularınızı iletebilirsiniz. Size yetkili birimler tarafından en kısa sürede dönüş yapılacaktır.</p>
                        <h3>Mağazamızın Konumu</h3>
                        <ul class="list-unstyled li-space-lg">
                            <li class="media">
                                <i class="fas fa-map-marker-alt"></i>
                                <div class="media-body">22 Innovative, San Francisco, CA 94043, US</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-mobile-alt"></i>
                                <div class="media-body">+90 968 554 33 32, &nbsp;&nbsp;<i class="fas fa-mobile-alt"></i>&nbsp; +90 968 554 33 34</div>
                            </li>
                            <li class="media">
                                <i class="fas fa-handshake"></i>
                                <div class="media-body"><a class="light-gray">Mağazamızda sizi ağırlayalım.</a> <i class="fas fa-globe"></i><a class="light-gray" href="#your-link">Teknik Servis</a></div>
                            </li>
                        </ul>
                    </div>
                    <!-- end of text-container -->
                </div>
                <!-- end of col-6 -->

                <div class="col-lg-6">

                    <!-- Contact Form -->
                    <form action="#" method="post" data-toggle="validator" data-focus="false" runat="server">
                        <div class="form-group">
                            <asp:TextBox ID="txtSenderName" CssClass="form-control-input" runat="server"></asp:TextBox>
                            <label class="label-control" for="cname">Adınız</label>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtSenderEmail" CssClass="form-control-input" runat="server"></asp:TextBox>
                            <label class="label-control" for="cemail">Email</label>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtMessageTitle" CssClass="form-control-input" runat="server"></asp:TextBox>
                            <label class="label-control" for="cmessage">Konu</label>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtMessageContent" CssClass="form-control-input" runat="server" TextMode="MultiLine" Height="50"></asp:TextBox>
                            <label class="label-control" for="cmessage">Mesajınız</label>
                            <div class="help-block with-errors"></div>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSend" CssClass="form-control-submit-button" runat="server" Text="GÖNDER" OnClick="btnSend_Click" />
                        </div>
                    </form>
                    <!-- end of contact form -->

                </div>
                <!-- end of col-6 -->
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

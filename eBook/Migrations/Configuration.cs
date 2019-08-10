namespace eBook.Migrations
{
    using eBook.App_Start;
    using eBook.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eBook.DAL.SiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eBook.DAL.SiteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Books.AddOrUpdate(
                p => p.ProductId,
                new Models.Book()
                {
                    ProductId = 1,
                    Title = "the bible",
                    Author = "god",
                    Description="the book given from god to israel people",
                    genre="Religion",
                    Price=200,
                    publisher="tora",
                    Image = "https://d3m9l0v76dty0.cloudfront.net/system/photos/521767/large/df63ff97af102350e8fe9a1e03fb10b4.jpg",
                    Video = @"https://www.youtube.com/watch?v=JTBFnWlurqU",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                },
                new Models.Book()
                {
                    ProductId = 2,
                    Title = "Talmud",
                    Author = "rabbai shtinzlatz",
                    Description = "talmud bavli",
                    genre = "Religion",
                    Price = 200,
                    publisher = "tora",
                    Image = "https://www.korenpub.com/media/catalog/product/cache/7/image/335x335/9df78eab33525d08d6e5fb8d27136e95/t/a/talmudbavliset_2_3_1.jpg",
                    Video = @"https://www.youtube.com/watch?v=tYOCTfok5Lg",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                },
                new Models.Book()
                {
                    ProductId = 3,
                    Title = "how bibi make israel empire",
                    Author = "akiva bigman",
                    Description = "bibi make israel empire",
                    genre = "Politics",
                    Price = 52,
                    publisher = "Balfur",
                    Image = "https://cdn.shopify.com/s/files/1/2776/1306/files/b4570895aece3f9e977e21ebbd1ea220_large.jpeg?v=1564913501",
                    Video = @"https://www.youtube.com/watch?v=H0Mp_BMVSTE",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                },
                new Models.Book()
                {
                    ProductId = 5,
                    Title = "Be free jewish",
                    Author = "Moshe feiglin",
                    Description = "israel - guide",
                    genre = "Politics",
                    Price = 25,
                    publisher = "keter",
                    Image = "https://cdn.shopify.com/s/files/1/2776/1306/products/3721fa825accb121168287d73c7a81f0_1024x1024.PNG?v=1550060324",
                    Video = @"https://www.youtube.com/watch?v=9rcSM9J0xS0",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                },
                new Models.Book()
                {
                    ProductId = 4,
                    Title = "Tehilim",
                    Author = "King David",
                    Description = "bible book for prays",
                    genre = "Religion",
                    Price = 43,
                    publisher = "koren foundation",
                    Image = "https://d3m9l0v76dty0.cloudfront.net/system/photos/947184/large/deedb3f0ec738f637da08c0622d5595d.jpg",
                    Video = @"https://www.youtube.com/watch?v=wexLc0wfgbU",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                }
                ,
                new Models.Book()
                {
                    ProductId = 6,
                    Title = "Golda - biography",
                    Author = "yosi goldshtein",
                    Description = "bio of prime minister",
                    genre = "politics",
                    Price = 28,
                    publisher = "yediot",
                    Image = "data:image/jpeg;base64,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",
                    Video = @"https://www.youtube.com/watch?v=A0Ys8Yp_nB4",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                },
                new Models.Book()
                {
                    ProductId = 7,
                    Title = "Golda - biography",
                    Author = "yosi goldshtein",
                    Description = "bio of prime minister",
                    genre = "politics",
                    Price = 28,
                    publisher = "yediot",
                    Image = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxISEhISEhIVFRUVFRUVFRYVFRUVFRUVFRUWFhUVFRUYHSggGBolHRUVITEhJSkrLi4uFx8zODMtNygtLisBCgoKDg0OGBAQGi0lHR0tLS8tLS0tLS0tLS0tLS0tLS0tLSstLS0tLS0tLS0tLSstLSstLy0tLS0rLS0tLS0tK//AABEIARYAtQMBIgACEQEDEQH/xAAcAAABBAMBAAAAAAAAAAAAAAAEAgMFBgABBwj/xABLEAABAwIEAgYECAsHAwUAAAABAAIDBBEFEiExBkETIlFhcYEHMpHBI0JzobGy0fAUJDM0UlRicoKz4RYlNVOSk6JDdPEVY4PC0v/EABkBAAMBAQEAAAAAAAAAAAAAAAECAwAEBf/EACgRAAICAgICAQIHAQAAAAAAAAABAhEDEiExMkFRYaEEEzRCcYLBIv/aAAwDAQACEQMRAD8A01icEadaxONjXiUd1g/RrOjRXRrYjTamsGDFnRosRLOiRUTWCtjS2xokRpTY02prB2xpwRohsaWI0VE1g7Y0trE+I0rImUQWMiNOCNOtYl5EaQbGQxKDE8GJQYikaxoMSsqebGlhiNGBgxKEafDEoMWoDGQxKyp4NWZUyRgWQLE5K1YjRrIFjE+yNKjYn2sXOkCxno1vo0R0a3kTKIbBxGs6NEhi3kTUCwbIlBiI6NA4qXA04aSM0wabcx0chsfMD2I0FcugpsaXkUVLQ1DGNIe+UjoQ4MOVxDMwkcMzrXdmBt+yhjDWNEXVmdzIDmFwAqA8NfdwBcYhlvrujqUWO/aJ8MSmtvqFFRYbN+KlzpC4OAmAkOXKGPOovr1soPatU+GTRutH0gibLCGtdJf4NmbpCNdGm7dO7ZGgaL5JkRpYjQODUsvRytkD25nuMed/SOaxzG26wPJ2bmhThtQ2ZgBlcAYPhOktHlYAJg+Mu1LrHkd91qMoK2rJoMSgxC4NQStDXSudfIGFjjexD3nNe5uSHAeQUq2JESVJ0Dhi3kRbYlvo0BbBMiUI0V0a2GIgbBhGt5ETkWi1agbEfMzXYrERK3VYmo1kFE1PtakRNRDWqKQwmy3lTmVKDUyRhoNWwxPhqU1iILGQxKEaIDEsNRRrGWxpwRJ5rUsNRBYwI0oRp8NWwEyQLG2xpWRbhka4Xa4OFyLggi4NiNOYKeyrUaxnKtsCeyrAEKNY3ZbsnLLeVbVmsZsssncqzKjqARlSSE9ZJyplEFgcw1WJyYarSajWQcYRTGpiMIuNq5hzQanA1KASZpWsGZ7mtHa4ho9pTJGFBq2Aoabi7D2Gxq4b9zw76t0Rh/EVHMcsVTE536IeA4+DTqm1YNkSgalhqwBCVeMU0TsktRDG6wOV8jGusdjYlFIzdB7QlgKJHE1D+uU/+9H9q3/aqg/Xab/ej+1NqwbIlgFyX0ocXTdM+jgeY2MAErmmz3ucA7Lm3DQCNtzddMoMcpZ3ZIaiKR1i7KyRrjlFgTYHbUe1cN9IA/vKs+UH8tirjjzySyy44Op+iVtsMh/fm/mvVzsudejbiKjgoIo5qmKN4fKS1zwHAGRxBt4FWn+2WHfrsH+sLSi7DCS1ROZVsBNQ1cboxM14MZbnDweqWWvmB7LKG/tvhv67B/qS0PaJ8Bbsm6mrjjYZJHtYwC5c9wa0DvJVek9IOGA2/C2HvDZHD2htlqYHJFkssshcLxaCpbngmZK0bljgbdxG4PijbLUCxOVIcE7ZaIRowFPusSpxqsQMQUSMYEJEEXGuUqOBcCxOlqausqGMbLO5s0oA6z8jRI4NFzoxultbBd9UXX19JQRlzyyJrnOdlaOtI8m7iGjVziTqVbHLXonkjZyuD0a4g4XLYmdzpNf+II+dQGPYFUUbwyoZlzXLSCHNcBuWuHZcab6hegMJrmzwxTNBDZGB4DrXAcLgG2l1TfTJGDRxHmKhtvOOS/0BVhkbdMnPGlG0MeijieSXPSTOLyxueJzjd2QEBzCedrtI8T2Ib0gcIVlVWOmgiDmGONt87G6tvfQm/NVz0VuIxGHvZKD4dGT7gu6gLS/5laDFbRpnDB6O8S/yB/uxf/pRGNYLNSODJw1ryL5Q9j3Aci4NJsDyuvRwC8y4rVPlmmlebue9zj5k2HgBYeACpjm5E8kVHo6d6MOGKqnqBUSsAifAcpD2knOY3N6oNxoCguLuBK6oraiaKNhY94LSZGg2DGjY7agrpvDo/Fab5CL6jVI2S7ux9E1RwwejPEv8uP8A3WqnyNLXOad2kg+INivUgC8vYifhpvlZPruVIybJzio9HfuHT/dEH/ZD+SvOzn9X+H3L0Rw422EQA/qTfnhXnX4v8PuQj7Dk6R6B9JWHy1NA2KFhe90sNmi3LUkk6ADtK53Xei6uihdMXQuLGlzo2ucXWAucpLbE25LuVP6rf3R9CaxIgRSXIHUdvp8UpFJodwvk828NY2+jqI6hhIykZwNnx3GdpHPT57FemmuvqNl5OHqfw+5erKL8mz9xv0BGQuMIWisC0UhUFn3WLJ91iwSDiRTELEi2LkKC1wLjDEHz1tQ55JyyPjaOTWRuLQB2bX8SV31eeMdaTV1VgT+MT7D/AN1y6MHbI5k3SR3Dgo/iFH8hH9CgfTD+ZR/9wz6kileBq+I0dLGJWdI2JgczO3OCBqC29wVFemA/iLL/AOez6kiWHmNNNQ5RR/Rd/iMHhL/Keu7hcI9GI/vGnPIiWx5H4F67jPVMjGaR7WN7XODR7SqZOxcSdBK8vS+s7xd9JXoyLiSjcQ0VUNzoB0jdfDVec5nDM7xP0psL7Bni1Vo9K8N/mlL8hF/LapJV3BsZp4aSlEs8bD0EOjntB/Jt5XuheKuKYxQ1MlJURmVjW2LXNc5uZ7Wk5T3OOtkvsprJR2rgK404pioYHEuBmc0iKO+rnbZiOTRuT5brg2C4ZJVzxwMuXSOsT2Dd7z3AXKMw/Bquue6UZnDeSomcRG225fK7TTsFz3LrXo9wqgpQWw1EU9Q4dd4c3NYalsbb6M9t+aragRUZZOa4RaKqnDKZ7GizWQua0dzWEBeX7dX+H3L1DjdQyOnmc9wa3I4XcbC7hlaL95IHmvMn4M/L6jtv0T2LQZssXSZ6Sx3HI6KkNRJrla0NaN3vNg1o8T7BcrilPHW41VEPkJABe4m/RQsGwawaX5DmeZ0JVx9KmLwTYfEIpmPLJos4a4EtvFKNezYqQ4N/BMNpAyeaNlRK0STNJu9pc27GFouRZpHmSeaVNJWNpOUtaOJH1Se4/QvVVD+Tj/cb9ULy2aV9rZXEkGwAJJ07l6koPycf7jfqhFtPoWMXFtNUELRK2klKUBpt1tam3WIGIKIophQkSKYuNFR66qzOBqcvkklL5C9732zFjRmcXW6up33urQqdw9ikk2I1LXuOVjZGMb8VobI1t7dptv3olsW6UnF1Q1xLwXAyCSWDMx0bS+2YuBDdSOtcg22sVLcD1xqaQdL13McWEuF72ALSb87OtfuUjxF+a1PyMv1CoH0Yfm0nyx+oxMijk54G5c0wDhVoGLVVgNOntpt8I3bsSOO4RJiNLG+5a4QtIvbR0zmut2G3NXLCsEjgkmlFy+Z7nOceQJuGNHIfSk4xhEE8kUshyvgc14cHAaBwcGvB+KS36bI0FZ4/mbfSvsDVPBFC9haIchto9rnZge3UkHzUFwDVPhqZqCWzg3PkuBo5h1t3OBvb7VaKjiamZcdIHW3ygu+cKkYHiMb8Wlqc2WPrkE6Xu0MHt3TVQuObnCam7SX3LnU8H0ks0k8rC90hboXFrW5WtaAA0i/q81TPSHw1BSiKWBtmucWuYSXtuBmaRmvpoQQr4OIKcmwlb7fv2qr+k+oD6eGxBHTcvk3otcA/D5ZPJGLfBcY6aOopWxlobHJE27WdUBrgDlFtvJc+43wqKjqKN9M3oySSbOcdWOZYi5/aN1csPxFsVJE95s1kLCT3BgXPOJsWlqzTzvY1kfSPbCBfMWgszOceethpbYrS5Q/4VSU3XjydB9I3+Hz+MX86Nb9Hf+Hwf/J/Neh+Ppb0E4+T/msT3o6d+IQeMn816P7iT/T/ANv8K56MqVkk1aHsa8AsNnNDgDnksdee6uE/ClI+aSeSISPkIJz9Zos0NADdho0IvA8HipWFsQ9Zxc9x1c5x5k/QFJIpcciZszc3KPByz0h4JFRmCppW9E7ORZpIAcBma5o5bFdNops8cb/0mNd/qAPvVK9LcRNNE4DRsuvddjgL+at2Dfm8HyUf1AguJMbM9sMG+7YatFbWiqHKCznVYsm3WImIGIolqFYUQ0rhTLIeBVawDh+WCsnnc5hZJ0mUNJzdeQOFwR2BWMFKBTDxm4ppexrE6cywyxggF8b2AnYFzSBf2qH4Vwt1DA9sz2avL7tJtbK0cwNeqpyaUNaXHYC5XNMZxWWqk0NowbADmE8VYu7UXH0ydxbjgashH8R9wVVkjmqZM8b3F1rG9xoLnt2UoYmhoDGxgW2I61+ZudypbAsOIjcRu7QkcgNwFTihYTcXaKo3CKhxLTIzvyn28gpOhwVlrRuce0kWN/Hayv2H8PNyj57gE+ZKkY+F2aWFtdwLarIeeaUlr0vpwc/qMEuA03J5G3vHPxUfi+ETOYyK9wHA93YPpXW4+Gm8/wCvmU7/AOiNFja9vvdO4slGesrT5RzKdhnpBT3ykdG0nuY5t7eTStYzhHTNgYxwY2G4AIJ06th/xXRXYBGQWhu9z5qj17HRSOYeS2tjrNKPT+fuGYzEamB8IdlzZdSLgZXtdt5I3henNPAyEuDi3NqBYHM4u281CxVKPpqlChfzJa6+uy2QyqrYvwtWSzSSMxCSNjnXawdJZosBbR4HzKWo6i6lIn3QasMMkoO0UebgOreC1+JPc06FrhI4HxBkVo4VweSkhMUkxm612kgjK3K0BgBcdBb51LgpQWUUg5M85rV9fwYtFbKQ5MRBpjqsWpt1ixiBjRDChWIhhXCmdA5dLBTV1jn2BPYnRiH4vrC2HIN5Dl8uarlFRsaCTyte1tzy+/Yk8RVpkeNzv26Dk0W270RhrGiMB36RIbp7SrLhE32StLSZm3NgOViT5+Cn8EpbZhysD5DYWUdFYNAvqbX5bnQeHcpimfr3DbvH/hCwpFhpIxy7vbzKkYyoulltbwRzpez5/sTwlROasKDltBibvC2ZFVTE0YSQqVx3hwLembu3Q97SftVuMllBcSHNDKP2D9F0JSDGJzZrkVBNZBApxjlglhoqhT1LLsqlSSKfoJUrCTzCloeB90+gY3dJKwlaKIAebdYtTHVYiEr7Cn2FDMTwK4Ey48o3iGp6OFxva5A9qPuoPjJhNM4j4pB93vVI9gfRWKVwdch2rtBe9hte/gEaJwHdW2UWJdbe/IfSoGmmDQG/GIP9VOvpwIgL3Nrnwta3zKpMnaeqa5rXDYXNz3Af19qlMJqi4jTQgG3iTY/MqUKg5A0a2sLDe+wACu3DNGWs629gD3HcgeGyD4GRNy1QiYXnkL9m2yrdXxLXetHGMp20v5diOx2Jz4y3UXsCR2X1UNiNbNEzLTQ5yNDf1Wac9dT3BaJmO0XG1SxwbPTOLTpmtlI9yuGF402Y5W8m3N+V7Wv86oEcVc9rXula4kOL4i1tmn4oGXX7FYOEJiGDO3K+3W8fHmnYpM41xEyla0vv1g61he5FlUazj+OQECF1nCxvvroToivSZFKY4nRNzWJB0va+qrGD4lOA1k8DcrrtDg0NIIGgcOw+SZdAsyOQOAI2KcBTTWgbbXJ9pS2pxSQpXKcoZNVXqcqcoXahKwlipnIwFAUrka1LYWKuklbSSiAHn3W1qc6rETFdYU8wodhTzVwJnRQ4CgMdjzwSDtCOum57ZXX2sb3ToDORyTda401RsNe4Ag7FpHv9yAmAzuttc28OSIjaC0gb/QPuF0kCx8K2dK4kaN1H0D7966TQ6NVJ4NoR0b5L3JNj7AferTFOQSD3Kb5KxXBJVFK2QAa+06eSbjpsgyloLe37QVkVUBunhPm22ShAqiBmU9G2zrb20b3lO01M1oAHZYdqTi9QI2XOgFyfJROCYkHRGWR4aCTa5sMoOm/31TroVlnmpxJEWnmPn5Kux4a2xa6Ox57aEKao8UjyjW/fyI7imquRri5zT3X8gijHPHtykjsJHsKwFO12kj/3imGlXJBlOVN0R2UHT7qaozslYUWCkcjmlR9GUcCpMI7dJKTdYimahibdYtTHVYmsxW4ynwUNGU80rgR0Dl0Lip+Bk/cd9CJukSsDgQeYsqJgaOPucQi8PF3Aduh7hzT2NULoJC23O4O4ITVAXF7co1uLdxXVfBCuTp+C4YyC/Rh1n6uLjubaWA0H9FLVUItfsG/eq5W4hUCOPK27szc1jsARfTwU+JAW+P2KJbgQ0kiw35I+nszdCMaAQBy0Tzo76XWMRvEP4zkgadSbu7ox6xPzDzSp+HonhocxpDdgdvYmoZXxmTqFxLyDYtBs02aLuI5a+JKjsT4unisBRuynS5cP/rdOr9CMP/8ARADla7K24vk0GnZyHsQ1HUGI1LHOLsjiQTzaQC0eIBsg6XjUyHI2kkzaZv2bobEpnF8hOmdwsP2WtAB9t/YmS55A2CveSSTuTc+axqQlMVSYZTqao1EUrdVNUjUrGRNUnJGtKCpQiwVJhHLrLpAK3dYAzOdViTMdViJitsKeBQ7CnmrhizpHLrd0i6hcfxMNY5jT1joT2BUXIG6IHizFo5HZGNvl0zfYgeG4XOlBaPV1/oo6qGqmOFcUbBKA+2V1rns/a8O3+i6aqPBC+bZ0V0OZrTa1rXS4Ictx36eCNMQczM3UEX7b9iZazndSTLC4he6abVlpdpqB2+xNzSZFDCpc55N9LgkDnYf+PYigMnRFdtna33Ped1GVkErRlZGJWndpNlJYfVsIsSpWCoZ4JkwMqtN1NG0/Rk7klp8SAOag64m4afi5h/zdZXjGJ4wC64s0Ern8smYknmqw+ScujQTkabCfhanEJCkapulaoujapqmakkx0SEIsE+CmGJy6mFjl1l03mSgVgDM+6xZNusRMVphTzSmGlOgrz0zoBa6U2sNFVq9itdU24VdxGPddGNk5orlQExGQSATbsKKqWoCRdMSRcOFuK3U56KYnoxsQLmMb372knbkuj0b2u1bYgi4ttY6+xciwSmhqgYJHFkv/AEX6ZSf0Hee3ipDBcXmoHvpp7gA6AalpPx2m2rD2Kco/HY8ZUdFxWMZdxb6FBQw3II2Olxt3FajqZJXkts4AbtdofEI972xR3eQ22pvsghysYnVFk2X1Bm9bwbfzvdY/GJ2xl8smVg9Xq2e/sABTMM/4XVh7G3Yw9UctPjn78lFVUMla6bX4aIutHydG0m4Z+0PnVUiTYbDjRnFiTfm377p0Kn07yCCDsrJQVYe39obj3qoga1GUwQbCjKcrMKJmkapenCh6V6lIHqUh0Hgrd0y16XdIFjuZbBTV0oFEU1MdVpam3WImK4xOAplqcBXnI6TJRoobEIVNIKpjVYsWSKbVxqLmarLXwnXRQNWLLrgyDQI3RWugeMQaKeZ9qho+AlOmaw/JPI5HtVUATkUlvtCdoCLPwtixoZ3QVEdm5iJG2dmabaEHW4XSq7hanrYQWSXY9oLTuR2HXY9ypuBTwYmwU9UctQ0fBSjR0jR8Rx5m19OzZIZPXYK+7gHQv6rdXvY4Ag2/Zda59u6VJXdBt0XDh/gBtMHfClziLXAAHiAqhxvgxoaqmnjJOZoDjsS+MAOdptca+1dU4d4hgrGF0Lrltg4EWIJGm+40Ovcoj0hYIKqleLddnwjNL6tBuPMXVXBJWhFJ3TOS8aYQI5Ip4xaKpZ0gA2a//qNHmQfPuUJA8tIIOoVtwwfhdFU0x9aEfhEF9fUb8IwW0AIJ81TWlBdBZY6Ota/uPZ9ikInqogkEbjmFK0WJjRr/AG/aiAtdNOpOGdVuGVSEE6VoZMsMcqIa9QsM6OilSNDWHhyUCho9BYJ5pShNyFYorHcQfDkyNDs2a9wdLWtt4rSNoZY21aAmlLCaaUteciwu6blathbToDREVsWirdZDurlURXUJXUi6MciMolWkbyTJUnUU2qEfAuhMmxqGZzSHNJDgbgg2II2IK67wNxVHWxmmq7GXv2kFvWb2O7QuSZVkMro3New5XNILSNwQdETHQuKOAqmncJKIySx+sW5znaWm4sARm5gc0JQekqqa0sna2UFmTRuV4cAQS52tzprftV64H4uFXEAbCRh+FZ3H47O0X5clO1eD0kou+CJ/WzasHrdvinituhW67OP8FNd03T2vGx4a43NvhDbwIsDz5qv8Q4cKerngB0Y8hv7p1b8xC71XQRNiLGRtDQQcoFh1SDy8Fyf0mUo/CmztItM0H+JgDT82VCtXyG7Q5h8kNRSxskFixpjzC1y9tstza9i3bXcqt4lhxiPa07H3FO4TUhmZh9V9r9xGzh7T7VLVBvdj9bjQjUG+xP03SdMPZGYTVEdQ7cvsU1HIq8I7HwU1TuzAFOKSsEykaeZQkSkKdyVjImopEU1yjYXI2NyVjIGxj4vn7lizFfi+fuWLlyeTOrH4oi2lKukArLrnFHLpQKazLYcmRhbhdBVESLutOF06YCv1kY/R+97qOmfqeoLctB7b2VmqKW6iamj7lWNCNshpJRZ3UGt7aDQEacuSaNVpbI29gASByHhr2o6SlIQz6dVSQmzFUWLPieJGANIt6vV7b6jkb2t3BdMwTGG1DBI17xqC5l/VcBYt7wd+9cu6BH4TVPgfmbz0cORCOse0DeR1KYgnMHkAnNYHQ7ffzVI4nOU5TqLuczz3b9+YCmoa8OaHNOh1/oo7G4RKy/Nuo94TtRlyZSkitipJ+KN7pcMrgAABoLa+N0qKnRcVMhpH4NvL5GC4uvoNUVRRWuiIqVFxQWRVJcAbb7Go40XC1KZEiI40LNQ7CEZEUPG1EMQsKGMS+L5+5YsxE+r5+5aXPk8jqx+KIi63mWLFziGZlgcsWIoxsOSsyxYiY2HLT4wdwsWJ0Zg0tC0oCegCxYqJsm0Cmmst/g4WLFVMRhlESzTkdwpAlaWI2AY6AXT7IwsWLGH2Rp9rFixBhHWtTzWrSxFAH2BOBaWLGBcR+L5+5YsWLnyeR1Y/FH//2Q==",
                    Video = @"https://www.youtube.com/watch?v=A0Ys8Yp_nB4",
                    TwitterWidgets = @"<a class=""twitter-timeline""  href=""https://twitter.com/search?q=%E2%80%8E%23IDFAidToMEX"" data-widget-id=""912076817728720896"">ציוצים על ‎#IDFAidToMEX</a>" + Environment.NewLine +
                    @"<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+""://platform.twitter.com/widgets.js"";fjs.parentNode.insertBefore(js,fjs);}}(document,""script"",""twitter-wjs"");</script>"
                }

               );

            



            context.Roles.AddOrUpdate(

                    r => r.Id,

                    new Role() { Id = "1", Name = IdentityConfigGlobals.MANAGER_ROLE },

                    new Role() { Id = "2", Name = IdentityConfigGlobals.USER_ROLE }

                );

            if (!context.Users.Any(u => u.UserName == "founder2"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { Email = "founder2@me.com", UserName = "founder2", Birthday = DateTime.Today, Address = "Tel Aviv" };

                try
                {
                    IdentityResult result = manager.Create(user, "12341234");
                }
                catch (Exception ex)
                {

                    throw;
                }

                manager.AddToRole(user.Id, IdentityConfigGlobals.MANAGER_ROLE);
            }

            if (!context.Users.Any(u => u.UserName == "member"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { Email = "member@me.com", UserName = "member", Birthday = DateTime.Today, Address = "Tel Aviv" };

                context.Users.Add(user);
                manager.Create(user, "12341234");
                manager.AddToRole(user.Id, IdentityConfigGlobals.USER_ROLE);
            }

            context.Comments.AddOrUpdate(
                c => c.CommentId,
                new Comment()
                {
                    CommentId = 1,
                    Author = "member",
                    Body = "Good One!",
                    ProductId = 1,
                    Rating = 5,
                    Title = "I Really Liked It",
                    date = new DateTime(2017,1,1)
                }
            );
        }
    }
}



()<script type="text/javascript">

    SIGNALR CON
        $(document).ready(() => {
            var connection = new signalR.HubConnectionBuilder().withUrl
    ("https://localhost:7088/SignalRHub").build();

    $("#connectionStatus").text("Baglanti Durumu " + connection.state);

            connection.start().then(() => {
        $("#connectionStatus").text("Baglanti Durumu " + connection.state);
                //INVOKE METHOD
                setInterval(() => {
        connection.invoke("SendCategory");
    connection.invoke("SendProduct");
    connection.invoke("SendOrder");
    connection.invoke("SendCase");             
                }, 1000)

            }).catch((err) => {console.log(err)});

            // KATEGORI ISLEMLERI
            connection.on("ReceiveCategoryCount", (category) => {

        $("#categoryCount").text(category);
            })

            connection.on("ReceiveAktiveProductCount", (categoryAktiveCount) => {

        $("#categoryAktiveCount").text(categoryAktiveCount);
            })

            connection.on("ReceivePassiveProductCount", (categoryPassiveCount) => {

        $("#categoryPassiveCount").text(categoryPassiveCount);
            })

            // URUN ISLEMLERI
            connection.on("ReceiveProductCount", (product) => {

        $("#productCount").text(product);
            })

            connection.on("ReceiveAVGproductPrice", (aVGProductPrice) => {

        $("#aVGProductPrice").text(aVGProductPrice + " TL");
            })
            // Gelen Liste Elemanlarini Tek Tek Alinmasi Gerekiyor
            connection.on("ReceiveMinproductPrice", (item1, item2) => {

        $("#minproductName").text(item1 + " TL");
    $("#minproductPrice").text(item2 );
                
            })
            // Gelen Liste Elemanlarini Tek Tek Alinmasi Gerekiyor
            connection.on("ReceiveMaxproductPrice", (item1, item2) => {


        $("#maxproductName").text(item1 + " TL");
    $("#maxproductPrice").text(item2 );
              
            })

            connection.on("ReceiveAVGHamburgerPrice", (Hamburger) => {

        $("#hamburgerAVG").text(Hamburger + " TL");
              
            })

            // SIPARIS ISLEMLERI
            connection.on("ReceiveTotalOrder", (totalOrder) => {
        $("#totalOrderCount").text(totalOrder);        
            })

            connection.on("ReceiveLastOrderPrice", (lastOrder) => {
        $("#lastOrderTotal").text(lastOrder + " TL");
            })

            connection.on("ReceiveAktiveOrderCount", (aktiveOrder) => {
        $("#aktiveOrdersCount").text(aktiveOrder);
            })

            connection.on("ReceiveTableCount", (table) => {
        $("#tableCount").text(table + " Adet");
            })

            connection.on("ReceiveTodayEarnig", (todayEarnig) => {
        $("#todayEarnig").text(todayEarnig + " TL");
            })
            // KASA ISLEMLERI
            connection.on("ReceiveTodayTotalCase", (totalCase) => {
        $("#totalCase").text(totalCase + " TL");
            })

        });
       
    </script>


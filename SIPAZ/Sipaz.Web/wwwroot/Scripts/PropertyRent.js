function LoadBasicDetails(Id) {
    $("#basic_details").load($BasicDetailsUrl+"?Id="+Id);
}

function LoadPropertyFeatures(Id) {
    $("#property_features").load($PropertyFeautresUrl + "?Id=" + Id);
}

function LoadPriceDetails(Id) {
    $("#price_details").load($PriceDetailsUrl + "?Id=" + Id);
}



$(document).ready(function () {
    var Id = $("PropertyId").val();
    LoadBasicDetails(Id);
    LoadPropertyFeatures(Id);
    LoadPriceDetails(Id);
});
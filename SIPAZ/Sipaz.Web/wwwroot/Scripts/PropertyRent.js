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
    var Id = $("#PropertyId").val();
    LoadBasicDetails(Id);
    LoadPropertyFeatures(Id);
    LoadPriceDetails(Id);
});

function BasicInt() {

    $("#frm_basic_details").submit(function (e) {
        debugger;
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: $SaveBasicDetails,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify($(this).serializeJSON()),
            headers: { Authorization: 'Bearer '+$token },
            success: function (data) {
                location.reload();
            }
        });

    });

}

function FeatureInt() {

    $("#frm_basic_details").submit(function (e) {
        debugger;
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: $SaveBasicDetails,
            data: $(this).serialize(),
            success: function (data) {
                location.reload();
            }
        });

    });

}


function PriceInt() {

    $("#frm_basic_details").submit(function (e) {
        debugger;
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: $SaveBasicDetails,
            data: $(this).serialize(),
            success: function (data) {
                location.reload();
            }
        });

    });

}

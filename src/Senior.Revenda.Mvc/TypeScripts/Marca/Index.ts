function AtivarMarca(sUrl, data) {
    let url = 'https://' + sUrl + '/Marca/Ativar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function() {
            location.reload();
        }
    });
}

function CancelarMarca(sUrl, data) {
    let url = 'https://' + sUrl + '/Marca/Cancelar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
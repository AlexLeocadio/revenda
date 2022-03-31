function AtivarProprietario(sUrl, data) {
    let url = 'https://' + sUrl + '/Proprietario/Ativar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}

function CancelarProprietario(sUrl, data) {
    let url = 'https://' + sUrl + '/Proprietario/Cancelar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
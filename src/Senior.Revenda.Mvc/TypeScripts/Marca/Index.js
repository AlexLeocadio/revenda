function AtivarMarca(sUrl, data) {
    var url = 'https://' + sUrl + '/Marca/Ativar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
function CancelarMarca(sUrl, data) {
    var url = 'https://' + sUrl + '/Marca/Cancelar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
//# sourceMappingURL=Index.js.map
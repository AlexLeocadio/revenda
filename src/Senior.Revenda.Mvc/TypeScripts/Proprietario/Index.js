function AtivarProprietario(sUrl, data) {
    var url = 'https://' + sUrl + '/Proprietario/Ativar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
function CancelarProprietario(sUrl, data) {
    var url = 'https://' + sUrl + '/Proprietario/Cancelar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
//# sourceMappingURL=Index.js.map
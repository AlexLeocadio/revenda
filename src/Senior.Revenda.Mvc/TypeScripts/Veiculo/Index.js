function VenderVeiculo(sUrl, data) {
    var url = 'https://' + sUrl + '/Veiculo/Vender/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
function IndisponibilizarVeiculo(sUrl, data) {
    var url = 'https://' + sUrl + '/Veiculo/Indisponibilizar/' + data;
    $.ajax({
        type: "POST",
        url: url,
        success: function () {
            location.reload();
        }
    });
}
//# sourceMappingURL=Index.js.map
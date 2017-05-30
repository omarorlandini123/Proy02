function mostrarPresupuestosPorSede(){
  var jqxhr = $.post( "EditNewDetallePresup.html", function(data) {
    $('#contenido-principal').html(data);
  });

}
function listarPorArea(sede,anio) {
    $.get("PorArea", { idSede: sede, anio: anio })
      .done(function (data) {
          $('#PresupPorArea').fadeOut(500, function () {
              $('#PresupPorArea').html(data).fadeIn(500);
          });
      });

}

function listarVersiones(area,sede, anio) {
    $.get("/Presupuesto/Versiones", {idArea:area, idSede: sede, anio: anio })
      .done(function (data) {
          $('#VersionesArea').fadeOut(500, function () {
              $('#VersionesArea').html(data).fadeIn(500);
          });
      });

function msgLogOut() {
    $('#idContenidoModal').html(EsperaModal());
    $.get("/Login/Logout", { idUsuario: 0 })
      .done(function (data) {
          $('#idContenidoModal').fadeOut(500, function () {
              $('#idContenidoModal').html(data).fadeIn(500);
          });
      })
    .fail(function (data) {
        $('#idContenidoModal').fadeOut(500, function () {
            $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
        });
    });

}

function msgAprobar(idPresupuesto) {

    $('#idContenidoModal').html(EsperaModal());
    $.get("../Presupuesto/AprobarPresup", { id: idPresupuesto })
      .done(function (data) {
          $('#idContenidoModal').fadeOut(500, function () {
              $('#idContenidoModal').html(data).fadeIn(500);
          });
      })
    .fail(function (data) {
        $('#idContenidoModal').fadeOut(500, function () {
            $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
        });
    });

}

function verAreasDisponibles(idPresup) {

    $('#PresupPorArea').html(getImgEspera());
    $.post("../Presupuesto/PorArea", { idPresupuesto: idPresup })
    .done(function (data) {
        $('#PresupPorArea').fadeOut(1000, function () {
            $('#PresupPorArea').html(data).fadeIn(1000);
        });
        
    })
    .fail(function (data) {
        $('#PresupPorArea').fadeOut(1000, function () {
            $('#PresupPorArea').html(getErrorMesaje()).fadeIn(1000);
        });
        
    });


}


function verTiposDisponibles(idPresup) {

    $('#PresupPorArea').html(getImgEspera());
    $.post("../Presupuesto/PorTipo", { idPresupuesto: idPresup })
    .done(function (data) {
        $('#PresupPorArea').fadeOut(1000, function () {
            $('#PresupPorArea').html(data).fadeIn(1000);
        });

    })
    .fail(function (data) {
        $('#PresupPorArea').fadeOut(1000, function () {
            $('#PresupPorArea').html(getErrorMesaje()).fadeIn(1000);
        });

    });


}


function LogOut() {
    $.post("/Login/Logout", { idUsuario: 0 })
    .done(function (data) {
        location.href = "/Login";
    });
    
}
function mostrarPresupuestosPorSede() {
  var jqxhr = $.post( "Presupuesto/PorSede", function(data) {
    $('#contenido-principal').html(data);
  });

}
function MostrarCrearPresup(idSede)
{
    $('#idContenidoModal').html(EsperaModal());
    $('#ModalGeneral').modal('show');
    $.get("/Presupuesto/MostrarCrearPresup", { idSede: idSede })
      .done(function (data) {
          $('#idContenidoModal').fadeOut(500, function () {
              $('#idContenidoModal').html(data).fadeIn(500);
          });
      })
    .fail(function (data) {
        $('#idContenidoModal').fadeOut(500, function () {
            $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
        });
    });

}
function CrearPerfil() {
    var nombre = $('#nombrePresupuesto').val();
    var codigoPerfil = $('#codigoPresupuesto').val();
    $('#idContenidoModal').html(EsperaModal());
    $('#ModalGeneral').modal('show');
    $.get("/Login/CrearPerfil", { nombre: nombre, codPerfil: codigoPerfil })
      .done(function (data) {
          $('#idContenidoModal').fadeOut(500, function () {
              $('#idContenidoModal').html(data).fadeIn(500);
          });
      })
    .fail(function (data) {
        $('#idContenidoModal').fadeOut(500, function () {
            $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
        });
    });
}
function CrearPresup() {
    var nombre = $('#nombrePresupuesto').val();
    var idSede = $('#idSede').val();
    var mesDesde = $('#mesDesde').val();
    var anioDesde= $('#anioDesde').val();
    var mesHasta = $('#mesHasta').val();
    var anioHasta = $('#anioHasta').val();
    $('#idContenidoModal').html(EsperaModal());
    $('#ModalGeneral').modal('show');
    $.get("/Presupuesto/CrearPresup", {nombre: nombre,idSede: idSede,mesDesde: mesDesde,anioDesde: anioDesde,mesHasta: mesHasta,anioHasta: anioHasta })
      .done(function (data) {
          $('#idContenidoModal').fadeOut(500, function () {
              $('#idContenidoModal').html(data).fadeIn(500);
          });
      })
    .fail(function (data) {
        $('#idContenidoModal').fadeOut(500, function () {
            $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
        });
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

var AreaSelect = '';
var TRSELECT = '';
var DIVSEl = '';


function ListarTipos(idPresupuesto) {
    $(AreaSelect).hide();
    $.get("/Presupuesto/TiposPresupuesto", { id: idPresupuesto, idArea: VAR_AREA_SEL })
      .done(function (data) {
          $('#TiposPresup_' + idPresupuesto).fadeOut(500, function () {
              $('#TiposPresup_' + idPresupuesto).show();
              $('#TiposPresup_' + idPresupuesto).html(data).fadeIn(500);
          });
      });
    AreaSelect = '#TiposPresup_' + idPresupuesto;
}

function listarVersiones(idPresupTipo) {
    $.get("/Presupuesto/Versiones/" + idPresupTipo, { idArea: VAR_AREA_SEL, })
      .done(function (data) {
          $('#VersionesArea').fadeOut(500, function () {
              $('#VersionesArea').html(data).fadeIn(500);
          });
      });
}

function NuevaVersion(idPresupTipo) {
    $('#idContenidoModal').html(EsperaModal());
    $('#ModalGeneral').modal('show');
    $.get("/Presupuesto/nuevaVersion", { id: idPresupTipo, idArea: VAR_AREA_SEL })
      .done(function (data) {
          $('#idContenidoModal').fadeOut(500, function () {
              $('#idContenidoModal').html(data).fadeIn(500);
          });
      })
    .fail(function (data) {
        $('#idContenidoModal').fadeOut(500, function () {
            $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
        });
    });

}



function ExpandirDetalle(codDetalle) {
    $(TRSELECT).hide();
    $(DIVSEl).html('');

    $('#DETALLEDIV_' + codDetalle).html(getImgEspera());
    $('#DETALLE_' + codDetalle).fadeIn(1000, function () {
        $.get("/Presupuesto/Edit", { id: codDetalle, idTipo: $('#idTipo').val() })
              .done(function (data) {
                  $('#DETALLEDIV_' + codDetalle).hide();
                  $('#DETALLEDIV_' + codDetalle).html(data);
                  $('#DETALLE_' + codDetalle).show();
                  $('#DETALLEDIV_' + codDetalle).fadeOut(500, function () {
                      $('#DETALLEDIV_' + codDetalle).html(data).fadeIn(500);

                      $('#codMaterial').keypress(function (e) {
                          if (e.which == 13) {//Enter key pressed
                              if ($('#idTipo').val() == 1) {
                                  getMateriales();
                              }
                              if ($('#idTipo').val() == 2) {
                                  getServicios();
                              }
                          }
                      });
                  });
                  $('.solo-numero').keyup(function () {
                      this.value = (this.value + '').replace(/[^0-9]/g, '');
                  });

          
              });

    });

    
    TRSELECT = '#DETALLE_' + codDetalle;
    DIVSEl = '#DETALLEDIV_' + codDetalle;

   

}


function EsperaDiv() {
    var retstring = '<div class="col-sm-10 col-sm-offset-1"><div class="panel panel-info"><div class="panel-body"><div class="form-group">';
    retstring = retstring + '<center>';
    retstring = retstring + getImgEspera();
    retstring = retstring + '</center><br/><center><h4>Espere Por Favor</h4></center></div></div></div></div>';
    return retstring;
}

function EsperaModal() {
    var retstring='<div class="modal-content">';
    retstring=retstring+'<div class="modal-body">';
    retstring=retstring+'<div class="form-group">';
    retstring=retstring+'<center>';
    retstring = retstring + getImgEspera();
    retstring = retstring + '</center><br/><center><h4>Espere Por Favor</h4></center></div></div></div>';
    return retstring;
}

function EsperaModalPERS(mensage) {

    var retstring = '<div class="modal-content">';
    retstring = retstring + '<div class="modal-body">';
    retstring = retstring + '<div class="form-group">';
    retstring = retstring + '<center>';
    retstring = retstring + '<h3>' + mensage + '</h3>';
    retstring = retstring + '</center></div></div></div>';
    return retstring;

}

function EsperaModalFAIL() {

    var retstring = '<div class="modal-content">';
    retstring = retstring + '<div class="modal-body">';
    retstring = retstring + '<div class="form-group">';
    retstring = retstring + '<center>';
    retstring = retstring + '<h3>Hubo un error solicitando los datos</h3>';
    retstring = retstring + '</center></div></div></div>';
    return retstring;
}

function getImgEspera() {

    return '<div class="row" style="height: 120px;"><div class="cssload-box-loading"></div></div>';
}

function getErrorMesaje() {
    return '<div class="row" style="height: 120px;"><center><h5>Hubo un error al consultar la informacion </h5></center></div>';
}

function ExpandirObservaciones(codDetalle){
    $(TRSELECT).hide();
    $(DIVSEl).html('');

    $('#DETALLEDIV_' + codDetalle).hide();
    $('#DETALLEDIV_' + codDetalle).html(getImgEspera());
    $('#DETALLE_' + codDetalle).show();

    $('#DETALLEDIV_' + codDetalle).fadeOut(500, function () {
        $('#DETALLEDIV_' + codDetalle).html(getImgEspera()).fadeIn(500, function () {

            $.get("/Presupuesto/Observaciones", { idDetalle: codDetalle })
             .done(function (data) {
                 $('#DETALLEDIV_' + codDetalle).fadeOut(500, function () {
                     $('#DETALLEDIV_' + codDetalle).html(data).fadeIn(500);
                 });
             })
               .fail(function (data) {
                   $('#DETALLEDIV_' + codDetalle).fadeOut(500, function () {
                       $('#DETALLEDIV_' + codDetalle).html(getErrorMesaje()).fadeIn(500);
                   });
               }) ;

        });
    });

   
    TRSELECT = '#DETALLE_' + codDetalle;
    DIVSEl = '#DETALLEDIV_' + codDetalle;
}

    function OcultarDetalle(codDetalle) {
        $('#DETALLE_' + codDetalle).hide();
    }



    var idObservacionSel = 0;
    function CambiarIdResolverObs(codDetalle,desDetalle) {
        idObservacionSel = codDetalle;
        $('#ObservacionInicial').html(desDetalle);
        $('#resObservacion').val('');
    }

    function MensajeObservarDetalle(mensaje) {

        $('#contObser').html(mensaje);
        $('#alertaObser').fadeIn(2000, function () {
            $('#alertaObser').fadeOut(2000);
        });
    }

    function ObservarDetalle(idObservarDetalle) {

        if ($('#commentObservacion').val() == "") {
            MensajeObservarDetalle('No se puede observar en blanco');
        } else {


            $('#btnObsGuardar').fadeOut(500, function () {
                $('#btnEspere').fadeIn(500);

                $.post("/Presupuesto/ObservarDetalle", { idDetalle: idObservarDetalle, observacion: $('#commentObservacion').val() })
                      .done(function (data) {
                          if (data) {
                              $('#btnEspere').fadeOut(500, function () {
                                  $('#btnObsAceptar').fadeIn(500);
                              });
                              MensajeObservarDetalle('Se ha guardado correctamente');
                          } else {
                              $('#btnEspere').fadeOut(500, function () {

                                  $('#btnObsGuardar').fadeIn(500);
                              });
                              MensajeObservarDetalle('Hubo un error al guardar, intente de nuevo');
                          }

                      })
                       .fail(function (data) {
                           MensajeObservarDetalle('Hubo un error con el servidor');
                       });
            });

        }
    
    }


    function MostrarResolucionObs(idObservacion) {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/MostrarResolucionObs", { idObservacion: idObservacion })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function ResolverObservacion(idObservacion) {
        $('#btnAceptarRes').fadeOut(500, function () {
            $('#btnEspereRes').fadeIn(500);

            $.post("/Presupuesto/ResolverObservacion", { idObservacion: idObservacion, observacion: $('#resObservacion').val() })
                  .done(function (data) {
                      if (data) {
                          $('#btnEspereRes').fadeOut(500, function () {
                              $('#btnObsAceptarRes').fadeIn(500);
                                                           
                          });

                      } else {
                          $('#btnEspereRes').fadeOut(500, function () {

                              $('#btnAceptarRes').fadeIn(500);
                          });
                      }

                  });
        });
    }
  

    function MostrarPanelNuevo(varidTipo) {
        $('#DIV_NEW_ITEM').html(EsperaDiv());
        $('#DIV_NEW_ITEM').fadeIn(500);
        $.post("/Presupuesto/Nuevo", { idTipo: varidTipo })
                  .done(function (data) {
                     
                          $('#DIV_NEW_ITEM').fadeOut(500, function() {
                              $('#DIV_NEW_ITEM').html(data);
                              $('.solo-numero').keyup(function () {
                                  this.value = (this.value + '').replace(/[^0-9]/g, '');
                              });

                              $('#DIV_NEW_ITEM').fadeIn(500);
                              $('#codMaterial').keypress(function (e) {
                                  if (e.which == 13) {//Enter key pressed
                                      if (varidTipo == 1) {
                                          getMateriales();
                                      }
                                      if (varidTipo == 2) {
                                          getServicios();
                                      }
                                  }
                              });
                          });


                      

                  });
    }

    function OcultarPanelNuevo() {
        $('#DIV_NEW_ITEM').fadeOut(500, function () {
            $('#DIV_NEW_ITEM').html('');
        });
       
    }

  
        function getListaDetalle(condicion) {



            $('#ListaDetalle').fadeOut(500, function () {
                $('#ListaDetalle').html(EsperaDiv());
                $('#ListaDetalle').fadeIn(500);
                $.get("/Presupuesto/DetallesVersion", { cond: condicion, idVersion: $('#idVersion').val(), idTipo: $('#idTipo').val() })
                      .done(function (data) {

                          $('#ListaDetalle').fadeOut(500, function () {
                              $('#ListaDetalle').html(data);
                              $('#ListaDetalle').fadeIn(500);
                          });



                      });
            });
        
        
        }

        function setMaterial(idMaterial) {
            $('#ListarMateriales').hide(250);
            $('#codMaterial').val(idMaterial);
            $('#desMaterial').val('Cargando ...');
            $('#desClase').val('Cargando ...');
            $('#precioUnit').val('Cargando ...');
            $('#unidMedida').val('Cargando ...');
            $('#desSubClase').val('Cargando ...');
            $('#cantidad').val(0);
            $('#unidSolicitada').val('Cargando ...');

            $('#totalsolic').val(0);

            $('#alto').val(0);
            $('#ancho').val(0);
            $('#largo').val(0);
            $.post("/Presupuesto/getMaterial", { cond: idMaterial })
            .done(function (data) {
                $('#codMaterial').val(data.codProducto);
                $('#desMaterial').val(data.desc);
                $('#desClase').val(data.subClase.clase.desClase);
                $('#precioUnit').val(data.precioUnit);
                $('#unidMedida').val(data.unidad);
                $('#desSubClase').val(data.subClase.desSubClase);
                $('#unidSolicitada').val(data.unidad);
            });
        }

        function getMateriales() {
            $('#desMaterial').val('Busque un Material');
            $('#desClase').val('Busque un Material');
            $('#precioUnit').val(0);
            $('#unidMedida').val('Busque un Material');
            $('#desSubClase').val('Busque un Material');
            $('#cantidad').val(0);
            $('#totalsolic').val(0);
            $('#unidSolicitada').val('Busque un Material');

            $('#ListarMateriales').html('<a href="#" class="list-group-item"> <p class="list-group-item-text"> Buscando ... </p></a>');
            $('#ListarMateriales').show(500);
            $.get("/Presupuesto/getMateriales", { cond: $('#codMaterial').val() })
                  .done(function (data) {

                      $('#ListarMateriales').html(data);

                      $("#codMaterial")
                      .focusout(function () {
                          window.setTimeout(function () { $('#ListarMateriales').hide(250); }, 500);

                      })


                  })
                .fail(function () {
                    $('#ListarMateriales').html('<a href="#" class="list-group-item"> <p class="list-group-item-text"> No se puede conectar </p></a>');
                    $("#codMaterial")
                     .focusout(function () {
                         window.setTimeout(function () { $('#ListarMateriales').hide(250); }, 500);
                     })

                });


        }

        function setServicio(idMaterial) {
            $('#ListarMateriales').hide(250);
            $('#codMaterial').val(idMaterial);
            $('#desMaterial').val('Cargando ...');
            $('#desClase').val('Cargando ...');
            $('#precioUnit').val('Cargando ...');
            $('#unidMedida').val('Cargando ...');
            $('#desSubClase').val('Cargando ...');
            $('#cantidad').val(0);
            $('#unidSolicitada').val('Cargando ...');

            $('#totalsolic').val(0);

            $('#alto').val(0);
            $('#ancho').val(0);
            $('#largo').val(0);
            $.post("/Presupuesto/getServicio", { cond: idMaterial })
            .done(function (data) {
                $('#codMaterial').val(data.codProducto);
                $('#desMaterial').val(data.desc);
                $('#desClase').val(data.subClase.clase.desClase);
                $('#precioUnit').val(data.precioUnit);
                $('#unidMedida').val(data.unidad);
                $('#desSubClase').val(data.subClase.desSubClase);
                $('#unidSolicitada').val(data.unidad);
            });
        }

        function getServicios() {
            $('#desMaterial').val('Busque un Servicio');
            $('#desClase').val('Busque un Servicio');
            $('#precioUnit').val(0);
            $('#unidMedida').val('Busque un Servicio');
            $('#desSubClase').val('Busque un Servicio');
            $('#cantidad').val(0);
            $('#totalsolic').val(0);
            $('#unidSolicitada').val('Busque un Servicio');

            $('#ListarMateriales').html('<a href="#" class="list-group-item"> <p class="list-group-item-text"> Buscando ... </p></a>');
            $('#ListarMateriales').show(500);
            $.get("/Presupuesto/getServicios", { cond: $('#codMaterial').val() })
                  .done(function (data) {

                      $('#ListarMateriales').html(data);

                      $("#codMaterial")
                      .focusout(function () {
                          window.setTimeout(function () { $('#ListarMateriales').hide(250); }, 500);

                      })


                  })
                .fail(function () {
                    $('#ListarMateriales').html('<a href="#" class="list-group-item"> <p class="list-group-item-text"> No se puede conectar </p></a>');
                    $("#codMaterial")
                     .focusout(function () {
                         window.setTimeout(function () { $('#ListarMateriales').hide(250); }, 500);
                     })

                });


        }

        function GuardarSustento()
        {
            
            var data = new FormData(); 
            var files = $('#archivoSustento').get(0).files;
            var codMaterial = $('#codMaterial').val();
            var desMaterial=$('#desMaterial').val();
            var cantidad = $('#cantidad').val();
            var prioridad = $('#prioridad').val();
            var desCriticidad = $('#desCriticidad').val();
            var largo = $('#largo').val();
            var ancho = $('#ancho').val();
            var alto = $('#alto').val();
            var sustento = $('#desSustento').val();
            var preciosoli = $('#precioUnit').val();
            var uniSoli = $('#unidMedida').val();

            var mesSoli = getChecksComoString('messoli');
            var mesEnt = getChecksComoString('mesent');
            var idVersion = $('#idVersion').val();
            var idTipo = $('#idTipo').val();
            // Add the uploaded image content to the form data collection 
            if (files.length > 0) { 
                data.append('UploadedImage', files[0]); 
            }

            data.append('codMaterial', codMaterial);
            data.append('nomMaterial', desMaterial);
            data.append('cantidad', cantidad);
            data.append('criticidad', desCriticidad);
            data.append('prioridad', prioridad);
            data.append('largo', largo);
            data.append('ancho', ancho);
            data.append('alto', alto);
            data.append('sustento', sustento);
            data.append('messoli', mesSoli);
            data.append('mesent', mesEnt);
            data.append('idVersion', idVersion);
            data.append('idTipo', idTipo);
            data.append('preciosoli', preciosoli);
            data.append('uniSoli', uniSoli);

            // Make Ajax request with the contentType = false, and procesDate = false 
            var ajaxRequest = $.ajax({ 
                type: 'POST', 
                url: "/Presupuesto/NuevoDetalle",
                contentType: false, 
                processData: false, 
                data: data 
            }); 
            ajaxRequest.done(function (xhr, textStatus) { 
                $('#ModalGeneral').modal('show');
                $('#idContenidoModal').html(xhr).fadeIn(500);

            });
            ajaxRequest.fail(function (xhr, textStatus) {
                $('#idContenidoModal').fadeOut(500, function () {
                    $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
                });
            });
    
        }
    
        function getChecksComoString(checkNombre) {

            var porcomas = '';
            if ($('input[name="' + checkNombre + '"]:checked').length > 0) {
                for (var a = 0; a < $('input[name="' + checkNombre + '"]:checked').length; a++) {
                    porcomas = porcomas + $('input[name="' + checkNombre + '"]:checked')[a].value + ",";
                } porcomas;
                porcomas = porcomas.substr(0, porcomas.length - 1);
            }
            return porcomas;
        }

    function ActualizarDetalle(idDetalle) {

        var data = new FormData();
        var codMaterial = $('#codMaterial').val();
        var desMaterial = $('#desMaterial').val();
        var cantidad = $('#cantidad').val();
        var prioridad = $('#prioridad').val();
        var desCriticidad = $('#desCriticidad').val();
        var largo = $('#largo').val();
        var ancho = $('#ancho').val();
        var alto = $('#alto').val();
        var sustento = $('#desSustento').val();
        var preciosoli = $('#precioUnit').val();
        var uniSoli = $('#unidMedida').val();

        var mesSoli = getChecksComoString('messoli');
        var mesEnt = getChecksComoString('mesent');
        var idVersion = $('#idVersion').val();
        var idTipo = $('#idTipo').val();

        data.append('idDetalle', idDetalle);
        data.append('codMaterial', codMaterial);
        data.append('nomMaterial', desMaterial);
        data.append('cantidad', cantidad);
        data.append('criticidad', desCriticidad);
        data.append('prioridad', prioridad);
        data.append('largo', largo);
        data.append('ancho', ancho);
        data.append('alto', alto);
        data.append('sustento', sustento);
        data.append('messoli', mesSoli);
        data.append('mesent', mesEnt);
        data.append('idVersion', idVersion);
        data.append('idTipo', idTipo);
        data.append('preciosoli', preciosoli);
        data.append('uniSoli', uniSoli);

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        // Make Ajax request with the contentType = false, and procesDate = false 
        var ajaxRequest = $.ajax({
            type: 'POST',
            url: "/Presupuesto/ActualizarDetalle",
            contentType: false,
            processData: false,
            data: data
        });
        ajaxRequest.done(function (xhr, textStatus) {
            $('#ModalGeneral').modal('show');
            $('#idContenidoModal').html(xhr).fadeIn(500);

        });
        ajaxRequest.fail(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });
    }

    function GuardarAccesos(varidperfil) {
        var data = new FormData();       
        var accesos = getChecksComoString('accperfil');

        data.append('accesos', accesos);
        data.append('codPerfil', varidperfil);
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        // Make Ajax request with the contentType = false, and procesDate = false 
        var ajaxRequest = $.ajax({
            type: 'POST',
            url: "/Login/GuardarAccesos",
            contentType: false,
            processData: false,
            data: data
        });
        ajaxRequest.done(function (xhr, textStatus) {
            $('#ModalGeneral').modal('show');
            $('#idContenidoModal').html(xhr).fadeIn(500);

        });
        ajaxRequest.fail(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function MostrarArchivos(varidDetalle)
    {        
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/VerArchivos", { idDetalle: varidDetalle })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

      
    }

    function MostrarAprobacionesVersion(varidVersion) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/AprobacionesVersion", { id: varidVersion })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });


    }

    function MostrarAprobacionesPresupuesto(varIdPresupuesto) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/AprobacionesPresupuesto", { id: varIdPresupuesto })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });


    }

    function MostrarEliminarDetalle(idDetalle) {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/MostrarEliminarDetalle", { idDetalle: idDetalle,idTipo : $('#idTipo').val() })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }
    function getAccesosDePerfil(varidperfil) {
       
        $('#listaAccesos').html(EsperaDiv());
        $('#listaAccesos').fadeIn(500, function () {

            $.get("/Login/getAccesosDePerfil", { idPerfil: varidperfil })
             .done(function (data) {
                 $('#listaAccesos').fadeOut(500, function () {
                     $('#listaAccesos').html(data).fadeIn(500);
                 });
             })
           .fail(function (data) {
               $('#listaAccesos').fadeOut(500, function () {
                   $('#listaAccesos').html(EsperaModalFAIL()).fadeIn(500);
               });
           });

        });
       

    }

    function EliminarPerfil(varidperfil) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Login/EliminarPerfil", { codPerfil: varidperfil })
          .done(function (data) {

              //$('#ModalGeneral').modal('hide');
              getListaDetalle('');
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }


    function MostrarCrearPerfil() {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Login/MostrarCrearPerfil", { })
          .done(function (data) {

              //$('#ModalGeneral').modal('hide');
              getListaDetalle('');
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function AprobarDetalle(idDetalle)
    {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/AprobarDetalle", { idDetalle: idDetalle })
          .done(function (data) {

              //$('#ModalGeneral').modal('hide');
              getListaDetalle('');
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function EliminarDetalle(idDetalle) {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/EliminarDetalle", { idDetalle: idDetalle })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function NuevoAprobadorVersion(varidVersion) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/NuevoAprobadorVersion", { id: varidVersion })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function NuevoAprobadorPresup(varidPresupuesto) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/NuevoAprobadorPresup", { id: varidPresupuesto })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function AgregarAprobVersion(varidVersion) {
        var orden = $('#idOrden').val();
        var usrApro = $('#idUserApro').val();
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/AgregarAprobVersion", { id: varidVersion, idOrden: orden, idUsuario: usrApro })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });
    }

    function AgregarAprobPresup(varidPresupuesto)
    {
        var orden= $('#idOrden').val();
        var usrApro=$('#idUserApro').val();
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/AgregarAprobPresup", { id: varidPresupuesto, idOrden: orden, idUsuario: usrApro })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });
    }


    function DesAprobarPresupuesto(varidPresupuesto) {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');

        $.get("/Presupuesto/DesAprobarPresupuesto", { id: varidPresupuesto })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })

        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });
    }

    function EnviarAprobacion(varidVersion) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');

        $.get("/Presupuesto/EnviarAprobacion", { id: varidVersion })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })

        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function AprobarVersion(varidVersion) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');

        $.get("/Presupuesto/AprobarVersion", { id: varidVersion })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })

        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function RechazarVersion(varidVersion) {
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');

        $.get("/Presupuesto/RechazarVersion", { id: varidVersion })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })

        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function AprobarPresupuesto(varidPresupuesto) {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');

        $.get("/Presupuesto/AprobarPresupuesto", { id: varidPresupuesto })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })

        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });
    }

    function VerDetalleAprobacion(varidAprobacion) {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');

        $.get("/Presupuesto/DetalleAprobacion", { id: varidAprobacion })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })

        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });
    }


    function EliminarArchivo(idArchivo,idDetalle) {

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        $.get("/Presupuesto/EliminarArchivo", { idArchivo: idArchivo, idDetalle: idDetalle })
          .done(function (data) {
              $('#idContenidoModal').fadeOut(500, function () {
                  $('#idContenidoModal').html(data).fadeIn(500);
              });
          })
        .fail(function (data) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });
    }

    function subirArchivo(varidDetalle) {


        var data = new FormData();
        var files = $('#archivoSustentoNuevo').get(0).files;

        // Add the uploaded image content to the form data collection 
        if (files.length > 0) {
            data.append('UploadedImage', files[0]);
        }

        data.append('idDetalle', varidDetalle);
       

        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        // Make Ajax request with the contentType = false, and procesDate = false 
        var ajaxRequest = $.ajax({
            type: 'POST',
            url: "/Presupuesto/SubirArchivo",
            contentType: false,
            processData: false,
            data: data
        });
        ajaxRequest.done(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(xhr).fadeIn(500);
            });

        });
        ajaxRequest.fail(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    


    }

    function MostrarObservarDetalle(idDetalle) {

        var data = new FormData();
        data.append('idDetalle', idDetalle);
        data.append('idTipo', $('#idTipo').val());

         $('#idContenidoModal').html(EsperaModal());
         $('#ModalGeneral').modal('show');
        var ajaxRequest = $.ajax({
                type: 'POST',
                url: "/Presupuesto/MostrarObservarDetalle",
                contentType: false,
                processData: false,
                data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(xhr).fadeIn(500);
            });

        });
        ajaxRequest.fail(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }

    function MostrarResolverObservacion(idObservacion) {

        var data = new FormData();
        data.append('idObservacion', idObservacion);
        data.append('idTipo', $('#idTipo').val());
        $('#idContenidoModal').html(EsperaModal());
        $('#ModalGeneral').modal('show');
        var ajaxRequest = $.ajax({
            type: 'POST',
            url: "/Presupuesto/MostrarResolverObservacion",
            contentType: false,
            processData: false,
            data: data
        });

        ajaxRequest.done(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(xhr).fadeIn(500);
            });

        });
        ajaxRequest.fail(function (xhr, textStatus) {
            $('#idContenidoModal').fadeOut(500, function () {
                $('#idContenidoModal').html(EsperaModalFAIL()).fadeIn(500);
            });
        });

    }


     $(document).ready(function () {
        $('[data-toggle="popover"]').popover();
            
        $('#cond_buscar').keypress(function (e) {
            if (e.which == 13) {//Enter key pressed
                getListaDetalle($('#cond_buscar').val());
            }
        });

        $('#codMaterial').keypress(function (e) {
             if (e.which == 13) {//Enter key pressed
                getMateriales();
            }
        });
        setTimeout(function () {
            LogOut();
        }, 300000);
     
     });


     function NumCheck(e, field) {
         key = e.keyCode ? e.keyCode : e.which
         // backspace
         if (key == 8) return true
         // 0-9
         if (key > 47 && key < 58) {
             if (field.value == "") return true
             regexp = /.[0-9]{8}$/
             return !(regexp.test(field.value))
         }
         // .
         if (key == 46) {
             if (field.value == "") return false
             regexp = /^[0-9]+$/
             return regexp.test(field.value)
         }
         // other key
         return false

     }
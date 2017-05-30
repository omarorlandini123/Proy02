create or replace PROCEDURE GET_DETALLE_VERSION (VAR_ID_VERSION IN NUMBER,CUR_RPTA OUT sys_refcursor)IS
BEGIN

    SAVEPOINT obtenerResultados;

    OPEN CUR_RPTA FOR
    select ID_DETALLE,COD_MATERIAL,CANT_SOLIC,PRECIO_UNI_SOLIC,CRITICIDAD,
    TOTAL_SOLIC,TIPO,LARGO,ANCHO,ALTO,SUSTENTO,UNID_SOLI,DET_V_FEC_REG,
    DET_V_ULT_FEC,DET_V_USR_REG,DET_V_ULT_USR,ID_PRIORIDAD,ID_VERSION 
    from T_DET_VERSION 
    WHERE ID_VERSION=VAR_ID_VERSION;


EXCEPTION 
        WHEN OTHERS THEN

            ROLLBACK TO obtenerResultados;
            RAISE;
END;
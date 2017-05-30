create or replace PROCEDURE GET_VERSION (
VAR_ID_VERSION IN NUMBER,
CUR_RPTA OUT sys_refcursor)IS
BEGIN

    SAVEPOINT obtenerResultados;

    OPEN CUR_RPTA FOR
    SELECT
    A.id_version,
    A.nro,
    A.id_presupuesto_tipo,
    A.id_area,
    A.v_fecha_reg,
    A.v_usuario_reg,
    A.v_ult_modif_fec,
    A.v_fecha_val_ini,
    A.v_fecha_val_fin,
    A.est_actual   
    FROM
        t_version A
        WHERE A.id_version = VAR_ID_VERSION
        ;


EXCEPTION 
        WHEN OTHERS THEN

            ROLLBACK TO obtenerResultados;
            RAISE;
END;
create or replace PROCEDURE GET_VERSIONES_PRESUPUESTO_TIPO (VAR_ID_PRESUP_TIPO IN NUMBER,CUR_RPTA OUT sys_refcursor)IS
BEGIN

    SAVEPOINT obtenerResultados;

    OPEN CUR_RPTA FOR
    SELECT
        id_version,
        nro,
        id_presupuesto_tipo,
        id_area,
        v_fecha_reg,
        v_usuario_reg,
        v_ult_modif_fec,
        v_fecha_val_ini,
        v_fecha_val_fin,
        est_actual
    FROM
        t_version
    where id_presupuesto_tipo=VAR_ID_PRESUP_TIPO;

    EXCEPTION 
        WHEN OTHERS THEN

            ROLLBACK TO obtenerResultados;
            RAISE;
END;
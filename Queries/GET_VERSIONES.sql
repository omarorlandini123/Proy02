create or replace PROCEDURE GET_VERSIONES (
VAR_ID_PRESUPUESTO_TIPO IN NUMBER, 
VAR_ID_AREA IN NUMBER,
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
    A.est_actual,
    B.id_presupuesto_tipo,
    B.id_presupuesto,
    B.id_tipo,
    B.pre_t_fecha_reg,
    B.pre_t_ult_modif_fec,
    B.pre_t_modif_usr,
    B.pre_t_fecha_val_ini,
    B.pre_t_fecha_val_fin,
    B.pre_t_est_actual
    ,NVL(SUM(C.TOTAL_SOLIC),0) MONTO
    FROM
        t_version A
        RIGHT JOIN T_PRESUP_TIPO B ON A.ID_PRESUPUESTO_TIPO = B.ID_PRESUPUESTO_TIPO 
        LEFT JOIN T_DET_VERSION C ON A.ID_VERSION= C.ID_VERSION
        WHERE A.ID_PRESUPUESTO_TIPO = VAR_ID_PRESUPUESTO_TIPO AND ID_AREA=VAR_ID_AREA
        GROUP BY 
    A.id_version,
    A.nro,
    A.id_presupuesto_tipo,
    A.id_area,
    A.v_fecha_reg,
    A.v_usuario_reg,
    A.v_ult_modif_fec,
    A.v_fecha_val_ini,
    A.v_fecha_val_fin,
    A.est_actual,
    B.id_presupuesto_tipo,
    B.id_presupuesto,
    B.id_tipo,
    B.pre_t_fecha_reg,
    B.pre_t_ult_modif_fec,
    B.pre_t_modif_usr,
    B.pre_t_fecha_val_ini,
    B.pre_t_fecha_val_fin,
    B.pre_t_est_actual    
    ORDER BY NRO DESC
        ;


EXCEPTION 
        WHEN OTHERS THEN

            ROLLBACK TO obtenerResultados;
            RAISE;
END;
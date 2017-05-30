create or replace PROCEDURE GET_PRESUPUESTOS_TIPO (VAR_ID_PRESUPUESTO IN NUMBER,CUR_RPTA OUT sys_refcursor)IS
BEGIN

    SAVEPOINT obtenerResultados;

    OPEN CUR_RPTA FOR
    SELECT
    A.id_presupuesto_tipo,
    A.id_presupuesto,
    A.id_tipo,
    A.pre_t_fecha_reg,
    A.pre_t_ult_modif_fec,
    A.pre_t_modif_usr,
    A.pre_t_fecha_val_ini,
    A.pre_t_fecha_val_fin,
    A.pre_t_est_actual,
    B.ID_TIPO_PRESUP,
    B.NOMBRE,
    NVL(SUM(E.TOTAL_SOLIC),0) MONTO
    FROM t_presup_tipo A
    INNER JOIN T_TIPO_PRESUP B ON A.ID_TIPO=B.ID_TIPO_PRESUP
    INNER JOIN  T_VERSION C ON A.ID_PRESUPUESTO_TIPO=C.ID_PRESUPUESTO_TIPO 
    INNER JOIN (SELECT max(nro) as nro,id_presupuesto_tipo,id_area
        FROM t_version group by id_presupuesto_tipo,id_area) D 
        ON C.NRO=D.NRO  AND D.ID_AREA=C.ID_AREA and D.id_presupuesto_tipo=A.ID_PRESUPUESTO_TIPO
    LEFT JOIN T_DET_VERSION E ON E.ID_VERSION=C.ID_VERSION
    WHERE A.ID_PRESUPUESTO=VAR_ID_PRESUPUESTO
    GROUP BY A.id_presupuesto_tipo,
    A.id_presupuesto,
    A.id_tipo,
    A.pre_t_fecha_reg,
    A.pre_t_ult_modif_fec,
    A.pre_t_modif_usr,
    A.pre_t_fecha_val_ini,
    A.pre_t_fecha_val_fin,
    A.pre_t_est_actual,
    B.ID_TIPO_PRESUP,
    B.NOMBRE;

EXCEPTION 
        WHEN OTHERS THEN

            ROLLBACK TO obtenerResultados;
            RAISE;
END;
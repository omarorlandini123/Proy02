create or replace PROCEDURE GET_PRESUPUESTO_AREAS(VAR_ID_PRESUP IN NUMBER,CUR_RPTA OUT sys_refcursor)IS
BEGIN

    SAVEPOINT obtenerResultados;

    OPEN CUR_RPTA FOR
    select a.ID_AREA,  c.ID_PRESUPUESTO,
        NVL(sum(d.TOTAL_SOLIC),0) as monto,
        NVL(max(d.DET_V_ULT_FEC),max(a.V_ULT_MODIF_FEC)) as ultmodif,
        min(a.V_FECHA_VAL_INI) as fechavalIni,
        max(a.V_FECHA_VAL_FIN) as fechavalfin
        --select *
        from t_version a
        inner join t_presup_tipo c on a.ID_PRESUPUESTO_TIPO=c.ID_PRESUPUESTO_TIPO
        left join T_DET_VERSION d on a.ID_VERSION=d.ID_VERSION
        inner join
        (SELECT
            max(nro) as nro,
            id_presupuesto_tipo,
            id_area
        FROM
            t_version 
            group by id_presupuesto_tipo,id_area) b 
            on a.nro=b.nro and a.id_presupuesto_tipo=b.id_presupuesto_tipo and a.id_area=b.id_area
            where  c.ID_PRESUPUESTO=VAR_ID_PRESUP
                group by c.ID_PRESUPUESTO,a.ID_AREA ;

    EXCEPTION 
        WHEN OTHERS THEN

            ROLLBACK TO obtenerResultados;
            RAISE;
END;
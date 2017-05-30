create or replace PROCEDURE GET_PRESUP_POR_SEDE (VAR_ID_SEDE IN NUMBER,CUR_RPTA OUT sys_refcursor)IS
BEGIN

    SAVEPOINT obtenerResultados;

    OPEN CUR_RPTA FOR

        select e.ID_PRESUPUESTO as id_presupuesto,
        max(e.fecha_reg) as fecha_reg,
        max(e.usuario_reg) as usuario_reg,        
        NVL(sum(d.TOTAL_SOLIC),0) as monto,
        NVL(max(d.DET_V_ULT_FEC),NVL(max(a.V_ULT_MODIF_FEC),max(e.ULT_MODIF_FEC))) as ult_modif_fec,
        max(e.ult_modif_user) as ult_modif_user, 
        NVL(min(a.V_FECHA_VAL_INI),min(e.FECHA_VAL_INI)) as fecha_val_ini,
        NVL(max(a.V_FECHA_VAL_FIN),max(e.FECHA_VAL_FIN)) as fecha_val_fin,
        max(e.est_actual) as est_actual,
        max(e.nomb_presup) as nomb_presup
        from 
        t_version a
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
            right join t_presup e  on e.ID_PRESUPUESTO=c.ID_PRESUPUESTO
            group by e.ID_PRESUPUESTO;


    EXCEPTION 
        WHEN OTHERS THEN

            ROLLBACK TO obtenerResultados;
            RAISE;
END;
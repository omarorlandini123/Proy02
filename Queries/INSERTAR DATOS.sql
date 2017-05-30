INSERT INTO T_PRESUP (FECHA_REG,USUARIO_REG,ULT_MODIF_FEC,ULT_MODIF_USER,FECHA_VAL_INI,FECHA_VAL_FIN,EST_ACTUAL,NOMB_PRESUP)
values
(SYSDATE,'consultor3',sysdate,'consultor3','01/01/2018','31/12/2018',5,'Presupuesto 2018 - I');

INSERT INTO T_PRESUP (FECHA_REG,USUARIO_REG,ULT_MODIF_FEC,ULT_MODIF_USER,FECHA_VAL_INI,FECHA_VAL_FIN,EST_ACTUAL,NOMB_PRESUP)
values
(SYSDATE,'consultor3',sysdate,'consultor3','01/01/2017','31/12/2017',4,'Presupuesto 2017 - I');

INSERT INTO t_tipo_presup (nombre) 
VALUES 
('Gasto Capital');

INSERT INTO t_tipo_presup (nombre) 
VALUES 
('Gasto Funcionamiento');

INSERT INTO t_presup_tipo (
id_presupuesto, id_tipo, pre_t_fecha_reg, pre_t_ult_modif_fec, pre_t_modif_usr, pre_t_fecha_val_ini,
pre_t_fecha_val_fin, pre_t_est_actual) VALUES 
(21,1,sysdate,sysdate,'consultor3','01/01/2018','31/12/2018',5);

INSERT INTO t_presup_tipo (
id_presupuesto, id_tipo, pre_t_fecha_reg, pre_t_ult_modif_fec, pre_t_modif_usr, pre_t_fecha_val_ini,
pre_t_fecha_val_fin, pre_t_est_actual) VALUES 
(21,2,sysdate,sysdate,'consultor3','01/01/2018','31/12/2018',5);

---- Teniendo en cuenta que se tienen las siguientes areas : Sistemas = 1 y Contabilidad = 2
--- Para SISTEMAS
INSERT INTO t_version ( nro,    id_presupuesto_tipo,    id_area,    v_fecha_reg,    v_usuario_reg,
    v_ult_modif_fec,    v_fecha_val_ini,    v_fecha_val_fin,    est_actual) 
VALUES (1,2,'1',SYSDATE,'CONSULTOR3',SYSDATE,'01/01/2018','31/12/2018',5);
INSERT INTO t_version ( nro,    id_presupuesto_tipo,    id_area,    v_fecha_reg,    v_usuario_reg,
    v_ult_modif_fec,    v_fecha_val_ini,    v_fecha_val_fin,    est_actual) 
VALUES (2,2,'1',SYSDATE,'CONSULTOR3',SYSDATE,'01/01/2018','31/12/2018',5);
INSERT INTO t_version ( nro,    id_presupuesto_tipo,    id_area,    v_fecha_reg,    v_usuario_reg,
    v_ult_modif_fec,    v_fecha_val_ini,    v_fecha_val_fin,    est_actual) 
VALUES (3,2,'1',SYSDATE,'CONSULTOR3',SYSDATE,'01/01/2018','31/12/2018',5);

INSERT INTO t_version ( nro,    id_presupuesto_tipo,    id_area,    v_fecha_reg,    v_usuario_reg,
    v_ult_modif_fec,    v_fecha_val_ini,    v_fecha_val_fin,    est_actual) 
VALUES (1,2,'2',SYSDATE,'CONSULTOR3',SYSDATE,'01/01/2018','31/12/2018',5);
INSERT INTO t_version ( nro,    id_presupuesto_tipo,    id_area,    v_fecha_reg,    v_usuario_reg,
    v_ult_modif_fec,    v_fecha_val_ini,    v_fecha_val_fin,    est_actual) 
VALUES (2,2,'2',SYSDATE,'CONSULTOR3',SYSDATE,'01/01/2018','31/12/2018',5);
INSERT INTO t_version ( nro,    id_presupuesto_tipo,    id_area,    v_fecha_reg,    v_usuario_reg,
    v_ult_modif_fec,    v_fecha_val_ini,    v_fecha_val_fin,    est_actual) 
VALUES (3,2,'2',SYSDATE,'CONSULTOR3',SYSDATE,'01/01/2018','31/12/2018',5);

--- para la ultima version de sistemas
insert into t_prioridad(nombre_prio) values('ALTA');
insert into t_prioridad(nombre_prio) values('BAJA');
insert into t_prioridad(nombre_prio) values('MEDIA');

INSERT INTO t_det_version (cod_material,    cant_solic,    precio_uni_solic,
    criticidad,    total_solic,    tipo,    largo,    ancho,    alto,    sustento,    unid_soli,    det_v_fec_reg,
    det_v_ult_fec,     det_v_usr_reg,    det_v_ult_usr,    id_prioridad,    id_version) 
VALUES ('3456873423',12.0,2.5,2,30.0,2,0,0,0,'se quiere comprar el material','uni',sysdate,sysdate,'consultor3','consultor3',1,2);
INSERT INTO t_det_version (cod_material,    cant_solic,    precio_uni_solic,
    criticidad,    total_solic,    tipo,    largo,    ancho,    alto,    sustento,    unid_soli,    det_v_fec_reg,
    det_v_ult_fec,     det_v_usr_reg,    det_v_ult_usr,    id_prioridad,    id_version) 
VALUES ('3567565634',13.0,2,2,26.0,2,0,0,0,'se quiere comprar el material','uni',sysdate,sysdate,'consultor3','consultor3',1,2);

select * 
from
t_presup_tipo a
LEFT join t_version b on a.ID_PRESUPUESTO_TIPO=b.ID_PRESUPUESTO_TIPO
LEFT JOIN T_DET_VERSION C ON C.ID_VERSION=B.ID_VERSION
WHERE A.ID_PRESUPUESTO=21;

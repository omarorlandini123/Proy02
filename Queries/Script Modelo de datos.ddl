-- Generado por Oracle SQL Developer Data Modeler 4.2.0.932
--   en:        2017-04-20 11:16:26 COT
--   sitio:      Oracle Database 11g
--   tipo:      Oracle Database 11g



CREATE TABLE t_aprob_presup (
    id_aprob_presup   INTEGER NOT NULL,
    id_nivel          INTEGER NOT NULL,
    estado            INTEGER,
    usuario_reg       VARCHAR2(100),
    fecha_reg         DATE,
    obs               VARCHAR2(500),
    id_presup         INTEGER NOT NULL,
    id_tp_presup      INTEGER NOT NULL,
    id_vsn            INTEGER NOT NULL,
    id_dtll           INTEGER NOT NULL
);

ALTER TABLE t_aprob_presup ADD CONSTRAINT aprobacion_presup_pk PRIMARY KEY ( id_aprob_presup );

CREATE TABLE t_archivo (
    id_archivo     INTEGER NOT NULL,
    nomb_archivo   VARCHAR2(100),
    tipo_archivo   VARCHAR2(100),
    ruta_archivo   VARCHAR2(250),
    arch_fec_reg   DATE,
    arch_usr_reg   VARCHAR2(100)
);

ALTER TABLE t_archivo ADD CONSTRAINT t_archivo_pk PRIMARY KEY ( id_archivo );

CREATE TABLE t_det_archivo (
    id_detalle   INTEGER NOT NULL,
    id_archivo   INTEGER NOT NULL
);

CREATE TABLE t_det_version (
    id_detalle         INTEGER NOT NULL,
    cod_material       VARCHAR2(100),
    cant_solic         NUMBER,
    precio_uni_solic   NUMBER,
    criticidad         INTEGER,
    total_solic        NUMBER,
    tipo               INTEGER,
    largo              NUMBER,
    ancho              NUMBER,
    alto               NUMBER,
    sustento           VARCHAR2(500),
    unid_soli          VARCHAR2(100),
    det_v_fec_reg      DATE,
    det_v_ult_fec      DATE,
    det_v_usr_reg      VARCHAR2(100),
    det_v_ult_usr      VARCHAR2(100),
    id_prioridad       INTEGER NOT NULL,
    id_version         INTEGER NOT NULL
);

ALTER TABLE t_det_version ADD CONSTRAINT t_detalle_version_pk PRIMARY KEY ( id_detalle );

CREATE TABLE t_mes_ent_sol (
    id_mes_entrega    INTEGER NOT NULL,
    id_detalle        INTEGER NOT NULL,
    mes               INTEGER,
    tipo              INTEGER,
    mes_ent_fec_reg   DATE,
    mes_ent_usr_reg   VARCHAR2(100)
);

ALTER TABLE t_mes_ent_sol ADD CONSTRAINT t_mes_ent_sol_pk PRIMARY KEY ( id_mes_entrega );

CREATE TABLE t_nivel_aprob (
    id_nivel            INTEGER NOT NULL,
    n_aprob_nombre      VARCHAR2(100),
    orden               INTEGER,
    n_aporb_usr_reg     VARCHAR2(100),
    fech_vigencia_ini   DATE,
    fech_vigencia_fin   DATE,
    n_aprob_fecha_reg   DATE
);

ALTER TABLE t_nivel_aprob ADD CONSTRAINT t_nivel_aprobacion_pk PRIMARY KEY ( id_nivel );

CREATE TABLE t_observaciones (
    id_observaciones   INTEGER NOT NULL,
    id_det             INTEGER NOT NULL,
    observacion        VARCHAR2(500),
    obs_usr_reg        VARCHAR2(100),
    osb_fec_reg        DATE,
    obs_usr_res        VARCHAR2(100),
    obs_fec_res        DATE,
    obs_res            VARCHAR2(500)
);

ALTER TABLE t_observaciones ADD CONSTRAINT t_observaciones_pk PRIMARY KEY ( id_observaciones );

CREATE TABLE t_presup (
    id_presupuesto   INTEGER NOT NULL,
    fecha_reg        DATE,
    usuario_reg      VARCHAR2(100),
    ult_modif_fec    DATE,
    ult_modif_user   DATE,
    fecha_val_ini    DATE,
    fecha_val_fin    DATE,
    est_actual       INTEGER,
    nomb_presup      VARCHAR2(150)
);

ALTER TABLE t_presup ADD CONSTRAINT t_presupuesto_pk PRIMARY KEY ( id_presupuesto );

CREATE TABLE t_presup_tipo (
    id_presupuesto_tipo   INTEGER NOT NULL,
    id_presupuesto        INTEGER NOT NULL,
    id_tipo               INTEGER NOT NULL,
    pre_t_fecha_reg       DATE,
    pre_t_ult_modif_fec   DATE,
    pre_t_modif_usr       VARCHAR2(100),
    pre_t_fecha_val_ini   DATE,
    pre_t_fecha_val_fin   DATE,
    pre_t_est_actual      INTEGER
);

ALTER TABLE t_presup_tipo ADD CONSTRAINT t_presupuesto_tipo_pk PRIMARY KEY ( id_presupuesto_tipo );

CREATE TABLE t_prioridad (
    id_prioridad   INTEGER NOT NULL,
    nombre_prio    VARCHAR2(100)
);

ALTER TABLE t_prioridad ADD CONSTRAINT t_prioridad_pk PRIMARY KEY ( id_prioridad );

CREATE TABLE t_tipo_presup (
    id_tipo_presup   INTEGER NOT NULL,
    nombre           VARCHAR2(100)
);

ALTER TABLE t_tipo_presup ADD CONSTRAINT t_tipo_presupuesto_pk PRIMARY KEY ( id_tipo_presup );

CREATE TABLE t_version (
    id_version            INTEGER NOT NULL,
    nro                   INTEGER,
    id_presupuesto_tipo   INTEGER NOT NULL,
    id_area               VARCHAR2(100),
    v_fecha_reg           DATE,
    v_usuario_reg         VARCHAR2(100),
    v_ult_modif_fec       DATE,
    v_fecha_val_ini       DATE,
    v_fecha_val_fin       DATE,
    est_actual            INTEGER
);

ALTER TABLE t_version ADD CONSTRAINT t_version_pk PRIMARY KEY ( id_version );

ALTER TABLE t_aprob_presup ADD CONSTRAINT t_aprb_presp_t_presp_tp_fk FOREIGN KEY ( id_tp_presup )
    REFERENCES t_presup_tipo ( id_presupuesto_tipo );

ALTER TABLE t_aprob_presup ADD CONSTRAINT t_aprb_presup_t_dtl_vsn_fk FOREIGN KEY ( id_dtll )
    REFERENCES t_det_version ( id_detalle );

ALTER TABLE t_aprob_presup ADD CONSTRAINT t_aprb_presup_t_nvl_aprb_fk FOREIGN KEY ( id_nivel )
    REFERENCES t_nivel_aprob ( id_nivel );

ALTER TABLE t_aprob_presup ADD CONSTRAINT t_aprb_presup_t_presup_fk FOREIGN KEY ( id_presup )
    REFERENCES t_presup ( id_presupuesto );

ALTER TABLE t_aprob_presup ADD CONSTRAINT t_aprb_presup_t_vsn_fk FOREIGN KEY ( id_vsn )
    REFERENCES t_version ( id_version );

ALTER TABLE t_det_archivo ADD CONSTRAINT t_det_arv_t_archivo_fk FOREIGN KEY ( id_archivo )
    REFERENCES t_archivo ( id_archivo );

ALTER TABLE t_det_archivo ADD CONSTRAINT t_det_arv_t_det_vsn_fk FOREIGN KEY ( id_detalle )
    REFERENCES t_det_version ( id_detalle );

ALTER TABLE t_det_version ADD CONSTRAINT t_det_version_t_version_fk FOREIGN KEY ( id_version )
    REFERENCES t_version ( id_version );

ALTER TABLE t_det_version ADD CONSTRAINT t_det_vsn_t_prioridad_fk FOREIGN KEY ( id_prioridad )
    REFERENCES t_prioridad ( id_prioridad );

ALTER TABLE t_mes_ent_sol ADD CONSTRAINT t_mes_entsol_t_det_vsn_fk FOREIGN KEY ( id_detalle )
    REFERENCES t_det_version ( id_detalle );

ALTER TABLE t_presup_tipo ADD CONSTRAINT t_prsup_tipo_t_presup_fk FOREIGN KEY ( id_presupuesto )
    REFERENCES t_presup ( id_presupuesto );

ALTER TABLE t_presup_tipo ADD CONSTRAINT t_prsup_tipo_t_tippre_fk FOREIGN KEY ( id_tipo )
    REFERENCES t_tipo_presup ( id_tipo_presup );

ALTER TABLE t_version ADD CONSTRAINT t_version_t_presup_tipo_fk FOREIGN KEY ( id_presupuesto_tipo )
    REFERENCES t_presup_tipo ( id_presupuesto_tipo );

ALTER TABLE t_observaciones ADD CONSTRAINT table_30_t_dtl_vsn_fk FOREIGN KEY ( id_det )
    REFERENCES t_det_version ( id_detalle );

-- Creación de secuencias para autoincrementar los contadores de tablas
-- ------------------------------------------------------------------------
CREATE SEQUENCE T_PRESUP_AI START WITH 1;
CREATE OR REPLACE TRIGGER T_PRESUP_AI_TRIG
BEFORE INSERT ON T_PRESUP
FOR EACH ROW
BEGIN
    SELECT T_PRESUP_AI.NEXTVAL
    INTO :new.ID_PRESUPUESTO
    FROM dual;    
END;


-- Datos de Prueba
-- ------------------------------------------------------------------------

INSERT INTO T_PRESUP (FECHA_REG,USUARIO_REG,ULT_MODIF_FEC,ULT_MODIF_USER,FECHA_VAL_INI,FECHA_VAL_FIN,EST_ACTUAL,NOMB_PRESUP)
values
(SYSDATE,'consultor3',sysdate,'consultor3','01/01/2018','31/12/2018',5,'Presupuesto 2018 - I');

commit;
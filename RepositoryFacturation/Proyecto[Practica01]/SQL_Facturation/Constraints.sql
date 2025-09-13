alter table Bills
add constraint pk_bills primary key(id_bill)

alter table Details
add constraint pk_detail primary key (id_detail)

alter table Details
add constraint fk_det_bills foreign key (id_bill) references Bills(id_bill)

alter table Details
add constraint fk_pro_det foreign key (id_product) references Products(id_product)


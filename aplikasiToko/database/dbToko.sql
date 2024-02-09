CREATE TABLE `produk`(
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `kode` VARCHAR(255) NOT NULL,
    `nama` VARCHAR(255) NOT NULL,
    `harga` INT NOT NULL,
    `stok` INT NOT NULL,
    `id_kategori` INT NOT NULL
);
ALTER TABLE
    `produk` ADD PRIMARY KEY `produk_id_primary`(`id`);
ALTER TABLE
    `produk` ADD UNIQUE `produk_id_kategori_unique`(`id_kategori`);
CREATE TABLE `detail_transaksi`(
    `id_transaksi` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `id_produk` INT NOT NULL,
    `jumlah_barang` INT NOT NULL,
    `jumlah_harga` INT NOT NULL
);
ALTER TABLE
    `detail_transaksi` ADD PRIMARY KEY `detail_transaksi_id_transaksi_primary`(`id_transaksi`);
ALTER TABLE
    `detail_transaksi` ADD PRIMARY KEY `detail_transaksi_id_produk_primary`(`id_produk`);
CREATE TABLE `detail_kredit`(
    `id_kredit` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `id_produk` INT NOT NULL
);
ALTER TABLE
    `detail_kredit` ADD PRIMARY KEY `detail_kredit_id_kredit_primary`(`id_kredit`);
ALTER TABLE
    `detail_kredit` ADD PRIMARY KEY `detail_kredit_id_produk_primary`(`id_produk`);
CREATE TABLE `transaksi`(
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `total_harga` DATE NOT NULL,
    `id_pegawai` INT NOT NULL,
    `id_costumer` INT NOT NULL
);
ALTER TABLE
    `transaksi` ADD PRIMARY KEY `transaksi_id_primary`(`id`);
ALTER TABLE
    `transaksi` ADD UNIQUE `transaksi_id_pegawai_unique`(`id_pegawai`);
ALTER TABLE
    `transaksi` ADD UNIQUE `transaksi_id_costumer_unique`(`id_costumer`);
CREATE TABLE `kredit`(
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `tenggat_waktu` DATE NOT NULL,
    `denda` INT NOT NULL,
    `id_transaksi` INT NOT NULL,
    `id_customer` INT NOT NULL,
    `id_pegawai` INT NOT NULL
);
ALTER TABLE
    `kredit` ADD PRIMARY KEY `kredit_id_primary`(`id`);
ALTER TABLE
    `kredit` ADD UNIQUE `kredit_id_transaksi_unique`(`id_transaksi`);
ALTER TABLE
    `kredit` ADD UNIQUE `kredit_id_customer_unique`(`id_customer`);
ALTER TABLE
    `kredit` ADD UNIQUE `kredit_id_pegawai_unique`(`id_pegawai`);
CREATE TABLE `costumer`(
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `nama` VARCHAR(255) NOT NULL,
    `telp` VARCHAR(255) NOT NULL,
    `alamat` VARCHAR(255) NOT NULL
);
ALTER TABLE
    `costumer` ADD PRIMARY KEY `costumer_id_primary`(`id`);
CREATE TABLE `kategori`(
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `nama` VARCHAR(255) NOT NULL
);
ALTER TABLE
    `kategori` ADD PRIMARY KEY `kategori_id_primary`(`id`);
CREATE TABLE `pegawai`(
    `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `nama` VARCHAR(255) NOT NULL,
    `telp` VARCHAR(255) NOT NULL,
    `alamat` VARCHAR(255) NOT NULL
);
ALTER TABLE
    `pegawai` ADD PRIMARY KEY `pegawai_id_primary`(`id`);
ALTER TABLE
    `transaksi` ADD CONSTRAINT `transaksi_id_pegawai_foreign` FOREIGN KEY(`id_pegawai`) REFERENCES `pegawai`(`id`);
ALTER TABLE
    `detail_kredit` ADD CONSTRAINT `detail_kredit_id_kredit_foreign` FOREIGN KEY(`id_kredit`) REFERENCES `kredit`(`id`);
ALTER TABLE
    `kredit` ADD CONSTRAINT `kredit_id_pegawai_foreign` FOREIGN KEY(`id_pegawai`) REFERENCES `pegawai`(`id`);
ALTER TABLE
    `kredit` ADD CONSTRAINT `kredit_id_transaksi_foreign` FOREIGN KEY(`id_transaksi`) REFERENCES `transaksi`(`id`);
ALTER TABLE
    `kredit` ADD CONSTRAINT `kredit_id_customer_foreign` FOREIGN KEY(`id_customer`) REFERENCES `costumer`(`id`);
ALTER TABLE
    `transaksi` ADD CONSTRAINT `transaksi_id_costumer_foreign` FOREIGN KEY(`id_costumer`) REFERENCES `costumer`(`id`);
ALTER TABLE
    `detail_transaksi` ADD CONSTRAINT `detail_transaksi_id_produk_foreign` FOREIGN KEY(`id_produk`) REFERENCES `produk`(`id`);
ALTER TABLE
    `detail_transaksi` ADD CONSTRAINT `detail_transaksi_id_transaksi_foreign` FOREIGN KEY(`id_transaksi`) REFERENCES `transaksi`(`id`);
ALTER TABLE
    `produk` ADD CONSTRAINT `produk_id_kategori_foreign` FOREIGN KEY(`id_kategori`) REFERENCES `kategori`(`id`);
ALTER TABLE
    `detail_kredit` ADD CONSTRAINT `detail_kredit_id_produk_foreign` FOREIGN KEY(`id_produk`) REFERENCES `produk`(`id`);
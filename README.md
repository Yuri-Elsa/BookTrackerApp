# 📚 Book Tracker App

Aplikasi sederhana buat catat koleksi buku pribadi — judul, penulis, harga, dan status udah/belum dibaca. Dibuat sambil belajar C#, OOP, dan ASP.NET Core MVC.

## Fitur

- Tambah, lihat, edit, dan hapus data buku (CRUD)
- Tandai buku sebagai "sudah dibaca" / "belum dibaca" langsung dari daftar (tanpa buka form edit)
- Ringkasan koleksi: total buku, jumlah selesai dibaca, jumlah belum dibaca, dan total nilai koleksi
- Validasi form (judul & penulis wajib diisi, harga tidak boleh negatif)

## Tech Stack

- **ASP.NET Core MVC** (.NET 8)
- **Entity Framework Core** (SQL Server)
- **Bootstrap** + jQuery untuk tampilan
- **SQL Server** sebagai database

## Struktur Project

```
BookTrackerApp/
├── Controllers/
│   ├── BookController.cs      # CRUD + toggle status baca
│   └── HomeController.cs
├── Models/
│   └── Book.cs                # Entity: Title, Author, Price, IsRead
├── Data/
│   └── ApplicationDbContext.cs
├── Migrations/
├── Views/
│   ├── Book/                  # Index, Create, Edit, Delete
│   └── Shared/
├── wwwroot/
└── appsettings.json
```

## Cara Menjalankan di Lokal

**Yang perlu disiapkan dulu:**
- [.NET 8.0 SDK](https://dotnet.microsoft.com/id-id/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express juga cukup)
- Visual Studio (opsional, bisa juga pakai CLI)

**Langkah-langkah:**

1. Clone repo ini
   ```bash
   git clone https://github.com/Yuri-Elsa/BookTrackerApp.git
   cd BookTrackerApp
   ```

2. Sesuaikan connection string di `appsettings.json` kalau perlu (default-nya pakai `localhost`):
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=BookTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. Buat database & jalankan migration:
   ```bash
   dotnet ef database update
   ```

4. Jalankan aplikasinya:
   ```bash
   dotnet run
   ```

5. Buka browser ke alamat yang muncul di terminal (biasanya `https://localhost:xxxx`)

## Deploy

Project ini juga dicoba di-hosting gratis pakai [MonsterASP.net](https://www.monsterasp.net):

1. Bikin website baru di Control Panel MonsterASP (pilih tipe ASP.NET Core Web App)
2. Aktifkan WebDeploy, download file `.publishSettings`
3. Di Visual Studio: klik kanan project → **Publish** → **Import Profile** → pilih file tadi
4. Sesuaikan connection string ke database yang disediakan MonsterASP
5. Klik **Publish**

## Status

Masih tahap belajar — dibuat untuk memenuhi tugas mingguan. Ke depannya mungkin ditambah fitur pencarian/filter buku dan autentikasi user.

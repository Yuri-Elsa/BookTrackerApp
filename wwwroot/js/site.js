// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener('DOMContentLoaded', function () {

    // ---------- Menu mobile ----------
    var navToggle = document.querySelector('.nav-toggle');
    var siteNav = document.querySelector('.site-nav');

    if (navToggle && siteNav) {
        navToggle.addEventListener('click', function () {
            var isOpen = siteNav.classList.toggle('is-open');
            navToggle.classList.toggle('is-open', isOpen);
            navToggle.setAttribute('aria-expanded', isOpen ? 'true' : 'false');
        });
    }

    // ---------- Preview kartu buku di form Tambah/Edit ----------
    var titleInput = document.getElementById('Title');
    var authorInput = document.getElementById('Author');
    var priceInput = document.getElementById('Price');
    var readInput = document.getElementById('IsRead');

    var previewTitle = document.getElementById('previewTitle');
    var previewAuthor = document.getElementById('previewAuthor');
    var previewPrice = document.getElementById('previewPrice');
    var previewBadge = document.getElementById('previewBadge');

    if (previewTitle && titleInput) {
        var formatRupiah = function (value) {
            var num = parseFloat(value);
            if (isNaN(num) || num < 0) num = 0;
            return 'Rp ' + num.toLocaleString('id-ID', { maximumFractionDigits: 0 });
        };

        var updatePreview = function () {
            previewTitle.textContent = titleInput.value.trim() || 'Judul Buku';
            previewAuthor.textContent = authorInput.value.trim() || 'Nama Penulis';
            previewPrice.textContent = formatRupiah(priceInput.value);

            if (readInput.checked) {
                previewBadge.textContent = 'Selesai Dibaca';
                previewBadge.className = 'badge-status badge-status--read';
            } else {
                previewBadge.textContent = 'Belum Dibaca';
                previewBadge.className = 'badge-status badge-status--unread';
            }
        };

        [titleInput, authorInput, priceInput, readInput].forEach(function (el) {
            el.addEventListener('input', updatePreview);
            el.addEventListener('change', updatePreview);
        });
    }

    // ---------- Auto-fit angka statistik ----------
    // Kelas ukuran dari server (--xl/--lg/--md/--sm/--xs) cuma tebakan awal
    // berdasar jumlah karakter. Di sini kita ukur lebar SEBENARNYA di layar
    // pengguna dan kecilkan font sampai benar-benar pas, tanpa pernah
    // memotong (ellipsis) angkanya. Kalau sudah di font minimum dan masih
    // kepanjangan (angka ekstrem), baru dibiarkan pindah baris.
    function fitStatValue(el) {
        if (!el.dataset.baseFontPx) {
            el.dataset.baseFontPx = parseFloat(window.getComputedStyle(el).fontSize);
        }

        var minPx = 11;
        var size = parseFloat(el.dataset.baseFontPx);

        el.style.whiteSpace = 'nowrap';
        el.style.fontSize = size + 'px';

        while (el.scrollWidth > el.clientWidth && size > minPx) {
            size -= 1;
            el.style.fontSize = size + 'px';
        }

        if (el.scrollWidth > el.clientWidth) {
            // Tetap kepanjangan walau sudah di ukuran minimum: biarkan wrap
            // daripada disembunyikan/dipotong.
            el.style.whiteSpace = 'normal';
        }
    }

    function fitAllStatValues() {
        document.querySelectorAll('.shelf-stat__value').forEach(fitStatValue);
    }

    if (document.querySelector('.shelf-stat__value')) {
        fitAllStatValues();

        var resizeTimer;
        window.addEventListener('resize', function () {
            clearTimeout(resizeTimer);
            resizeTimer = setTimeout(fitAllStatValues, 150);
        });
    }
});
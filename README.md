
<h2>TELEPERFORMANCE .NET BOOTCAMP BİTİRME PROJESİ - SHOPPING LIST</h2>
<h2>Gereksinim Listesi</h2>
<ul>
<li>Kullanıcıların almayı planladıkları ürünleri kaydedip takibini yapabilecekleri web api geliştirilecek.</li>
<li>Kategori bazlı liste oluşturulabilmeli:</li>
<li>Örn: market alışverişi, okul alışverişi. her bir listede hangi ürüne kadar.</li>
<li>Örn: 1 kg, 3 adet, 1 lt, 100 gr Vb. alındı mı? liste başlığı oluşturulan tarihi tamamlanan tarih</li>
<li>Not veya açıklama alanları yer almalıdır liste ekleme silme ve güncelleme yapılabilmeli liste adı,</li>
<li>kategori veya oluşturulma, tamamlanma tarihine göre arama yapabilmeli</li>
<li>Bu API’nin dışardan kullanabilmesi için token bazlı bir yapı geliştirilecek.</li>
<li>Kullanıcı sisteme kayıt olmadan işlem yapamayacak.</li>
<li>Sistemde iki tip rol olacak. Normal kullanıcı liste oluşturup onun üzerinde işlemler yapılabilecek.</li>
<li>Admin rolünde de oluşturulan tüm listeler görülebilecek.</li>
<li> Projede unit test yazılmalıdır.</li>
<li>En az bir akış için entegrasyon testi yazılmalıdır</li>
<li>Proje içinde gerekli görülen yerlerde cache kullanılmalıdır.</li>
<li>Kullanıcılar tarafından bir liste tamamlandı olarak işaretlendiğinde bir event fırlatarak tamamlanan bu
listenin bilgileri farklı bir veritabanında admin rolü tarafından görüntülenebilecek şekilde kaydedilecek..</li>
<li> Nosql veritabanı kullanılabilir.</li>
</ul>

<h2>Değerlendirme Kriterleri</h2>

<ul>
<li>Değişken isimleri anlamlı, amaç neyse ona göre verilmiş.</li>
<li>Metot isimleri ile metodun amacını net ifade edilmiş.</li>
<li>Class'ların içindeki metot sayısı az ve amaca yönelik belirlenmiş.</li>
<li>İç içe if ler olmayacak. Cyclomatic Complexity düşük tutulmuş.</li>
<li>Dry prensibi uygulanmış. Ayni kod parçasının tekrarlandığı duruma yer verilmemiş.</li>
<li>Kodu okumayı zorlaştıran conditional complexity yaratılmamış</li>
<li>Uzun metotlar (25 satırdan uzun).</li>
<li>Hardcoded değerler Const olarak isimlendirerek kullanılmış.</li>
<li>Aynı kodlama standardı tüm kodlarda uygulanmış. Farklı dosyalar arasında tutarsızlık
yaratılmamış.</li>
<li> Class'ların içindeki metotlar tek bir sorumluluk alanında odaklı yazılmış.</li>
<li> Objectler arası bağımlılıklar enjekte edilmiş.</li>
<li> Dependency Injection kullanılmış.</li>
<li> Classlar arası bağımlılıkların en azda tutulmasına dikkat edilmiş.</li>
<li> İnterface gibi abstraction lar ihtiyaç olduğu için kullanılmış. Gereksiz abstraction eklenmemiş.</li>
<li> İnterface içeriği az ve tek sorumluluğa özgü metot imzası barındıracak şekilde tasarlanmış. Gereksiz design
pattern kullanımı yapılmamış. Gerçekten bir problem çözmek için kullanılmış.</li>
<li> Open-Closed Prensibine dikkat edilmiş. Kod genişlemeye açık, değişikliğe kapalı şeklinde
tasarlanmış. Web/REST standartlarına dikkat edilmiş. Rest Api de açık metot
parametreler için defansif validation kodları yazılmış.</li>
<li>Command & Query Separation a dikkat edilmiş. Loglamaya dikkat edilmiş. Proje yapısını açıklayan Readme içerisinde yabancı birinin projeyi çekip nasıl çalıştıracağı gibi
bilgilendirmelere yer Maliyetli işlemler için caching gibi optimizasyonlar düşünülmüş.Exceptionlar ignore edilmemiş. Gereksiz overenginneering'e kaçan zorlama kod,
</ul>


Projenin Çalıştırılması için ProjeninCalistirilması.txt içindeki adımları takip edebilirsiniz.

# Project OData Server Change Logs

## E013 OData ile Post ve Put (2) | OData with Post & Put (2)

Bu 13. bölümde, Örneklerimizde daha karmaşık işler yapabilmek için varlıklarımızda bir düzenleme yapıyoruz. Bu sırada TPH (Table per Hierarchy) nedir onu inceliyoruz. Entity Framework Core'da nasıl kullanıldığını görüyoruz.

In this 13th episode, we adjust our assets to do more complex work in our Samples. Meanwhile, we examine what is TPH (Table per Hierarchy). We see how it is used in Entity Framework Core.

In dieser 13. Folge passen wir unser Vermögen an, um komplexere Arbeiten in unseren Samples auszuführen. In der Zwischenzeit untersuchen wir, was TPH (Tabelle pro Hierarchie) ist. Wir sehen, wie es in Entity Framework Core verwendet wird.

Dans ce 13ème épisode, nous ajustons nos ressources pour effectuer un travail plus complexe dans nos échantillons. Pendant ce temps, nous examinons ce qu'est TPH ( Table par hiérarchie). Nous voyons comment il est utilisé dans Entity Framework Core.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Inheritance On Entity Framework Core : https://docs.microsoft.com/en-US/ef/core/modeling/inheritance
2. Entity Framework Core: Enums : https://medium.com/agilix/entity-framework-core-enums-ee0f8f4063f2

-------------------

## E012 OData ile Post ve Put (2) | OData with Post & Put (2)

Bu 12. bölümde, sizlerle OData Serisi ve Project OData Series Projesi ile ilgili gelecek planlarımı ve şu anki çalışmalarım ile ilgili bilgiler paylaşmak istiyorum.

In this 12th episode, I would like to share with you information about my future plans for the OData Series and Project OData Series Project and my current work.

In dieser 12. Folge möchte ich Ihnen Informationen über meine zukünftigen Pläne für die OData-Serie und das Projekt OData Series Project und meine aktuelle Arbeit mitteilen.

Dans ce 12ème épisode, je voudrais partager avec vous des informations sur mes projets futurs pour la série OData et le projet OData Series Project et mon travail actuel.

-------------------

## E011 Loglama | Logging

Bu 11. bölümde, geliştirme sırasında birkaç kere bizi zorlayan logların çalışmaması problemini çözüyoruz. Bunu yaparken Asp.Net Core, Log4Net, Castle Windsor, Castle Logging Facility ve Microsoft.Extensions.Logging başlıklarını inceledik.  

In this episode 11, we solve the problem of logs not working, which has been forcing us several times during development. While doing this, we examined Asp.Net Core, Log4Net, Castle Windsor, Castle Logging Facility and Microsoft.Extensions.Logging.

In dieser Episode 11 lösen wir das Problem, dass Protokolle nicht funktionieren, was uns während der Entwicklung mehrmals gezwungen hat. Dabei haben wir Asp.Net Core, Log4Net, Castle Windsor, Castle Logging Facility und Microsoft.Extensions.Logging untersucht.

Dans cet épisode 11, nous résolvons le problème des logs qui ne fonctionnent pas, ce qui nous a obligé à plusieurs reprises au cours du développement. Ce faisant, nous avons examiné Asp.Net Core, Log4Net, Castle Windsor, Castle Logging Facility et Microsoft.Extensions.Logging.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Castle Logging Facility Source Code : [https://github.com/castleproject/Windsor/blob/master/src/Castle.Facilities.Logging/LoggingFacility.cs](https://github.com/castleproject/Windsor/blob/master/src/Castle.Facilities.Logging/LoggingFacility.cs)
2. Microsoft.Extensions.Logging.Log4Net.AspNetCore : [https://www.nuget.org/packages/Microsoft.Extensions.Logging.Log4Net.AspNetCore/](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Log4Net.AspNetCore/)

-------------------

## E010 OData ile Post ve Put (2) | OData with Post & Put (2)

Bu 10. bölümde, OData Kontrolörlerimizde yazdığımız Post ve Put metotları içindeki bir probleme el atıyoruz. Esasında bu, ilk yazdığımızda eksik bıraktığımız bir konu idi. Böylece ilişkili entity'leri de beraber kaydedip, değiştirebileceğiz.

In this 10th episode, we address a problem in the Post and Put methods we wrote in our OData Controllers. In fact, this was a subject we left incomplete when we first wrote. Thus, we will be able to save and change associated entities together.

In dieser 10. Folge behandeln wir ein Problem in den Post- und Put-Methoden, die wir in unseren OData-Controllern geschrieben haben. Tatsächlich war dies ein Thema, das wir beim ersten Schreiben unvollständig gelassen haben. Auf diese Weise können wir zugeordnete Entitäten gemeinsam speichern und ändern.

Dans ce 10ème épisode, nous abordons un problème dans les méthodes Post and Put que nous avons écrites dans nos contrôleurs OData. En fait, c'était un sujet que nous avons laissé incomplet lorsque nous avons écrit pour la première fois. Ainsi, nous pourrons enregistrer et modifier ensemble les entités associées.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Routing Conventions in ASP.NET Web API 2 Odata : https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-routing-conventions
2. DynamicEdmModelCreation : https://github.com/OData/ODataSamples/tree/master/WebApiCore/DynamicEdmModelCreation
3. Operations (OData Version 2.0) : https://www.odata.org/documentation/odata-version-2-0/operations/
4. Understand OData in 6 steps : https://www.odata.org/getting-started/understand-odata-in-6-steps/

-------------------

## E009 OData ile Patch | OData with Patch

Bu 9. bölümde, OData Kontrolörlerimizde olmasını isteyeceğimiz "Patch" özelliğini inceliyoruz. Ancak buna geçmeden önce, bir önceki bölümde "ProductController" üzerinde yapmayı unuttuğumuz bazı işleri tamamlayacağız.

In this 9th episode, we examine the "Patch" feature that we want to have on our OData Controllers. But before we get to that, we'll complete some work we forgot to do on "ProductController" in the previous episode.

In dieser neunten Folge untersuchen wir die "Patch" -Funktion, die wir auf unseren OData-Controllern haben möchten. Aber bevor wir dazu kommen, werden wir einige Arbeiten abschließen, die wir in der vorherigen Folge vergessen haben, an "ProductController" zu arbeiten.

Dans ce 9ème épisode, nous examinons la fonctionnalité "Patch" que nous souhaitons avoir sur nos contrôleurs OData. Mais avant d'en arriver là, nous terminerons le travail que nous avons oublié de faire sur "ProductController" dans l'épisode précédent.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Routing Conventions in ASP.NET Web API 2 Odata : https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-routing-conventions
2. DynamicEdmModelCreation : https://github.com/OData/ODataSamples/tree/master/WebApiCore/DynamicEdmModelCreation
3. Operations (OData Version 2.0) : https://www.odata.org/documentation/odata-version-2-0/operations/
4. Understand OData in 6 steps : https://www.odata.org/getting-started/understand-odata-in-6-steps/

-------------------

## E008 OData ile Post, Put ve Delete | OData with Post, Put & Delete

Bu 8. bölümde, OData Kontrolörlerimizde olmasını isteyeceğimiz üç özelliği inceliyoruz. Bu bölümde yazdıklarımız ile beraber OData Kontrolörlerimiz CRUD işlemlerinin tamamını yapabilecekler.

In this episode 8, we examine three features we would like to have in our OData Controllers.  With what we have written in this episode, our OData Controllers will be able to do all of the CRUD operations.

In dieser Episode 8 untersuchen wir drei Funktionen, die wir in unseren OData-Controllern haben möchten. Mit dem, was wir in dieser Episode geschrieben haben, können unsere OData-Controller alle CRUD-Operationen ausführen.

Dans cet épisode 8, nous examinons trois fonctionnalités que nous aimerions avoir dans nos contrôleurs OData. Avec ce que nous avons écrit dans cet épisode, nos contrôleurs OData pourront effectuer toutes les opérations CRUD.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Routing Conventions in ASP.NET Web API 2 Odata : https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-routing-conventions
2. DynamicEdmModelCreation : https://github.com/OData/ODataSamples/tree/master/WebApiCore/DynamicEdmModelCreation
3. Operations (OData Version 2.0) : https://www.odata.org/documentation/odata-version-2-0/operations/
4. Understand OData in 6 steps : https://www.odata.org/getting-started/understand-odata-in-6-steps/

-------------------

## E007 OData ile Select | OData With Select

Bu 7. bölümde, OData Kontrolörlerimizde olmasını isteyeceğimiz iki özelliği inceliyoruz. Böylece OData kontrolörlerimiz daha yetenekli olacaklar.

In this episode 7, we examine two features we would like to have in our OData Controllers. Thus, our OData controllers will be more capable.

In dieser Episode 7 untersuchen wir zwei Funktionen, die wir in unseren OData-Controllern haben möchten. Somit sind unsere OData-Controller leistungsfähiger.

Dans cet épisode 7, nous examinons deux fonctionnalités que nous aimerions avoir dans nos contrôleurs OData. Ainsi, nos contrôleurs OData seront plus performants.

-------------------

## E006 Dinamik Kontrolörler | Dynamic Controllers

Bu 6. bölümde projemize, projemizin en önemli parçalarından olan dinamik kod çalıştırma ile ilgileniyoruz. Yani çalışma zamanında string olarak hazırladığımız kodları derleyip, odata sunucumuzu bu dinamik kodlarla çalıştırıyoruz. Bu bölüm benim için en heyecan verici bölümlerden biri. Hadi ne duruyoruz, hemen başlayalım.

This 6th episode is about "dynamic code execution", one of the most important parts of our project. In other words, we compile the codes we have prepared as strings at runtime and run our OData server with these dynamic codes. This episode is one of the most exciting episodes for me. Come on, let's get started right away.

In dieser sechsten Folge geht es um die "dynamische Codeausführung", einen der wichtigsten Teile unseres Projekts. Mit anderen Worten, wir kompilieren die Codes, die wir zur Laufzeit als Zeichenfolgen vorbereitet haben, und führen unseren OData-Server mit diesen dynamischen Codes aus. Diese Folge ist eine der aufregendsten Folgen für mich. Komm schon, lass uns gleich loslegen.

Ce 6ème épisode concerne "l'exécution de code dynamique", l'une des parties les plus importantes de notre projet. En d'autres termes, nous compilons les codes que nous avons préparés sous forme de chaînes au moment de l'exécution et exécutons notre serveur OData avec ces codes dynamiques. Cet épisode est l'un des épisodes les plus excitants pour moi. Allez, commençons tout de suite.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Generic and dynamically generated controllers in ASP.NET Core MVC : [strathweb.com/2018/04/generic-and-dynamically-generated-controllers-in-asp-net-core-mvc/](https://www.strathweb.com/2018/04/generic-and-dynamically-generated-controllers-in-asp-net-core-mvc/)
2. ASP.Net Core register Controller at runtime : [stackoverflow.com/questions/46156649/asp-net-core-register-controller-at-runtime](https://stackoverflow.com/questions/46156649/asp-net-core-register-controller-at-runtime)
3. Generic controllers in ASP.Net Core : [www.ben-morris.com/generic-controllers-in-asp-net-core/](https://www.ben-morris.com/generic-controllers-in-asp-net-core/)
4. Share controllers, views, Razor Pages and more with Application Parts : [docs.microsoft.com/en-us/aspnet/core/mvc/advanced/app-parts?view=aspnetcore-3.1](https://docs.microsoft.com/en-us/aspnet/core/mvc/advanced/app-parts?view=aspnetcore-3.1) 
5. ASP. Net core to realize dynamic web API : [developpaper.com/asp-net-core-to-realize-dynamic-web-api/](https://developpaper.com/asp-net-core-to-realize-dynamic-web-api/)

-------------------

## E005 OData'ya Giriş | Introduction to OData

Bu 5. bölümde projemize, OData'yı ekliyoruz. Bir önceki bölümde hazırladığımız 2 varlığı dünyaya açacağız.

In this 5th section, we add OData to our project. We will open the 2 assets we prepared in the previous section to the world.

In dieser fünften Folge fügen wir unserem Projekt OData hinzu. Wir werden die 2 Assets, die wir im vorherigen Abschnitt vorbereitet haben, für die Welt öffnen.

Dans ce 5ème épisode, nous ajoutons OData à notre projet. Nous ouvrirons au monde les 2 actifs que nous avons préparés dans la section précédente.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. OData.org : [odata.org](https://www.odata.org/)
2. OData WebApi : [github.com/OData/WebApi](https://github.com/OData/WebApi)
3. Enabling Endpoint Routing in OData : [devblogs.microsoft.com/odata/enabling-endpoint-routing-in-odata/](https://devblogs.microsoft.com/odata/enabling-endpoint-routing-in-odata/)

-------------------

## E004 Entity Framework

Bu 4. bölümde projemize, Entity Framework ekliyoruz. Sqlite kullanan, 2 varlıktan oluşan bir Entity Framework uygulamasının nasıl yapıldığını göreceğiz.

In this 4th part, we add Entity Framework to our project. We will see how to make an Entity Framework application consisting of 2 entities using sqlite.

In dieser vierten Folge fügen wir unserem Projekt Entity Framework hinzu. Wir werden sehen, wie mit SQLite eine Entity Framework-Anwendung erstellt wird, die aus zwei Entitäten besteht.

Dans ce 4ème épisode, nous ajoutons Entity Framework à notre projet. Nous verrons comment créer une application Entity Framework composée de 2 entités à l'aide de sqlite.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Design-time DbContext Creation : [docs.microsoft.com/tr-tr/ef/core/miscellaneous/cli/dbcontext-creation](https://docs.microsoft.com/tr-tr/ef/core/miscellaneous/cli/dbcontext-creation)
2. Logging in Entity Framework Core : [entityframeworktutorial.net/efcore/logging-in-entityframework-core.aspx](https://www.entityframeworktutorial.net/efcore/logging-in-entityframework-core.aspx)

-------------------

## E003 Castle Windsor

Bu 3. bölümde projemize, Castle Windsor ve Log4net paketlerini ekliyoruz. Castle Windsor ile projemize tak çalıştır desteği gelirken, log4net ile loglama sistemimiz oluyor.

In this 3rd part, we add Castle Windsor and Log4net packages to our project. With Castle Windsor, we have plug and play support for our project, and we have a logging system with log4net.

In diesem dritten Teil fügen wir unserem Projekt die Pakete Castle Windsor und Log4net hinzu. Mit Castle Windsor haben wir Plug-and-Play-Unterstützung für unser Projekt und wir haben ein Protokollierungssystem mit log4net.

Dans cette 3ème partie, nous ajoutons les packages Castle Windsor et Log4net à notre projet. Avec Castle Windsor, nous avons un support plug and play pour notre projet, et nous avons un système de journalisation avec log4net.

### Bölüm linkleri | Episode links | Episodenlinks | Liens d'épisode

1. Castle Windsor : [github.com/castleproject/Windsor](https://github.com/castleproject/Windsor)
2. log4net : [logging.apache.org/log4net/](http://logging.apache.org/log4net/)

-------------------

## E002 Proje Hazırlığı | The project preparation

Bu 2. bölümde boş projemizi GitHub'dan indirip, yeni solution'ımızı oluşturuyoruz.

In this 2nd part, we download our blank project from GitHub and create our new solution.

In dieser zweiten Folge laden wir unser leeres Projekt von GitHub herunter und erstellen unsere neue Lösung.

Dans ce 2ème épisode, nous téléchargeons notre projet vierge depuis GitHub et créons notre nouvelle solution.

-------------------

## E001 Tanışma | Pilot | Pilotfolge | épisode pilote

Merhaba bu seride bir OData Server geliştirirken, yaşadıklarımı sizlerle paylaşmak istiyorum. Microsoft .Net Core 3.1 ve C# kullanarak geliştireceğim bu projeyi bütün adımlarıyla sizlerle paylaşacağım. Bu bölümde öncelikle OData ve projemiz ile ilgili bilgiler paylaşmak istiyorum.

Hello, I want to share with you what I have experienced while developing an OData Server in this series. I will share with you all the steps of this project that I will develop using Microsoft .Net Core 3.1 and C #. In this section, I firstly want to share information about OData and our project.  

Hallo, ich möchte Ihnen mitteilen, was ich bei der Entwicklung eines OData-Servers in dieser Serie erlebt habe. Ich werde Ihnen alle Schritte dieses Projekts mitteilen, die ich mit Microsoft .Net Core 3.1 und C # entwickeln werde. In diesem Abschnitt möchte ich zunächst Informationen über OData und unser Projekt austauschen.  

Bonjour, je souhaite partager avec vous ce que j'ai vécu lors du développement d'un serveur OData dans cette série. Je partagerai avec vous toutes les étapes de ce projet que je développerai en utilisant Microsoft .Net Core 3.1 et C #. Dans cette section, je souhaite d'abord partager des informations sur OData et notre projet.

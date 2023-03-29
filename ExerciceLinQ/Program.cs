using LinQ_DataContext;
using System.Security.Cryptography;

DataContext dc = new DataContext();

/*2.1*/
/*Ecrire une requête pour présenter, pour chaque étudiant, le nom de l’étudiant, la
date de naissance, le login et le résultat pour l’année de l’ensemble des étudiants.*/

/*var result_2_1 = dc.Students.Select(s => new { 
                                        Nom = s.Last_Name,
                                        DateNaissance = s.BirthDate,
                                        s.Login,
                                        Resultat = s.Year_Result });

var result_2_1 = from Student s in dc.Students
                 select new
                 {
                     Nom = s.Last_Name,
                     DateNaissance = s.BirthDate,
                     s.Login,
                     Resultat = s.Year_Result
                 };

foreach (var item in result_2_1)
{
    Console.WriteLine($"{item.Nom} {item.DateNaissance} {item.Login} {item.Resultat}");
}
*/
/*2.2*/
/*Ecrire une requête pour présenter, pour chaque étudiant, son nom complet (nom
et prénom séparés par un espace), son id et sa date de naissance.*/

/*var result_2_2 = from Student s in dc.Students
                 select new
                 {
                     NomComplet = s.Last_Name + " " + s.First_Name,
                     Id = s.Student_ID,
                     DateNaissance = s.BirthDate
                 };

var result_2_2 = dc.Students.Select(s => new {
                                            NomComplet = s.Last_Name + " " + s.First_Name,
                                            Id = s.Student_ID,
                                            DateNaissance = s.BirthDate
                                        });

foreach (var item in result_2_2)
{
    Console.WriteLine($"{item.NomComplet} {item.DateNaissance} {item.Id}");
}*/

/*2.3*/
/*Ecrire une requête pour présenter, pour chaque étudiant, dans une seule chaine de
caractère l’ensemble des données relatives à un étudiant séparées par le symbole |.*/

/*IEnumerable<string> result_2_3 = dc.Students.Select(s => string.Join(" | ", s.Student_ID, s.Last_Name, s.First_Name, s.BirthDate, s.Login, s.Year_Result, s.Section_ID, s.Course_ID));

IEnumerable<string> result_2_3 = from Student s in dc.Students
                                 select string.Join(" | ", s.Student_ID, s.Last_Name, s.First_Name, s.BirthDate, s.Login, s.Year_Result, s.Section_ID, s.Course_ID);

foreach (string item in result_2_3)
{
    Console.WriteLine(item);
}*/

/*3.1*/
/*Pour chaque étudiant né avant 1955, donner le nom, le résultat annuel et le statut.
Le statut prend la valeur « OK » si l’étudiant à obtenu au moins 12 comme résultat annuel
et « KO » dans le cas contraire.*/

/*var result_3_1 = dc.Students.Where(s => s.BirthDate.Year < 1955)
                            .Select(s => new
                            {
                                Nom = s.Last_Name,
                                Resultat = s.Year_Result,
                                Status = (s.Year_Result >= 12) ? "Ok" : "KO"
                            });
var result_3_1 = from Student s in dc.Students
                 where s.BirthDate.Year < 1955
                 select new {
                     Nom = s.Last_Name,
                     Resultat = s.Year_Result,
                     Status = (s.Year_Result >= 12) ? "Ok" : "KO"
                 };

foreach (var item in result_3_1)
{
    Console.WriteLine($"{item.Nom} {item.Resultat} : {item.Status}");
}*/

/*3.2*/
/*Donner pour chaque étudiant entre 1955 et 1965 le nom, le résultat annuel et la
catégorie à laquelle il appartient. La catégorie est fonction du résultat annuel obtenu ; un
résultat inférieur à 10 appartient à la catégorie « inférieure », un résultat égal à 10 appartient
à la catégorie « neutre », un résultat autre appartient à la catégorie « supérieure ».*/

/*var result_3_2 = dc.Students.Where(s => s.BirthDate.Year >= 1955)
                            .Where(s => s.BirthDate.Year <= 1965)
                            //.Where(s => s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965)
                            .Select(s => new
                            {
                                s.Last_Name,
                                s.Year_Result,
                                Category = s.Year_Result > 10 ? "Supérieur" : s.Year_Result == 10 ? "Neutre" : "Inférieur"
                            });

var result_3_2 = from Student s in dc.Students
                 where s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965
                 select new {
                                s.Last_Name,
                                s.Year_Result,
                                Category = s.Year_Result > 10 ? "Supérieur" : s.Year_Result == 10 ? "Neutre" : "Inférieur"
                            };

foreach (var item in result_3_2)
{
    Console.WriteLine($"{item.Last_Name} {item.Year_Result} : {item.Category}");
}*/

/*3.3*/
/*Exercice 3.3 Ecrire une requête pour présenter le nom, l’id de section de tous les étudiants
qui ont un nom de famille qui termine par r.*/

/*var result_3_3 = dc.Students.Where(s => s.Last_Name.ToLower().EndsWith("r")).Select(s => new { s.Last_Name, s.Section_ID });

//var result_3_3 = from Student s in dc.Students
//                 where s.Last_Name.ToLower().EndsWith("r")
//                 select new { s.Last_Name, s.Section_ID };

//foreach (var s in result_3_3)
//{
//    Console.WriteLine($"{s.Last_Name} {s.Section_ID}");
//}*/

/*3.4*/
/*Exercice 3.4 Ecrire une requête pour présenter le nom et le résultat annuel classé par résultats
annuels décroissant de tous les étudiants qui ont obtenu un résultat annuel inférieur ou égal
à 3.*/

/*var result_3_4 = dc.Students.Where(s => s.Year_Result <= 3)
//                            .OrderByDescending(s => s.Year_Result)
//                            .Select(s => new { s.Last_Name, s.Year_Result });

//var result_3_4 = from Student s in dc.Students
//                 where s.Year_Result <= 3
//                 orderby s.Year_Result descending
//                 select new { s.Last_Name, s.Year_Result };

//foreach (var s in result_3_4)
//{
//    Console.WriteLine($"{s.Last_Name} {s.Year_Result}");
//}
*/

/*3.5*/
/*Exercice 3.5 Ecrire une requête pour présenter le nom complet (nom et prénom séparés par un
espace) et le résultat annuel classé par nom croissant sur le nom de tous les étudiants
appartenant à la section 1110.*/
/*
//var result_3_5 = dc.Students.Where(s => s.Section_ID == 1110)
//                            .OrderBy(s => s.Last_Name)
//                            .Select(s => new { NomComplet = $"{s.Last_Name} {s.First_Name}", Resultat = s.Year_Result });

var result_3_5 = from Student s in dc.Students
                 where s.Section_ID == 1110
                 orderby s.Last_Name
                 select new { NomComplet = $"{s.Last_Name} {s.First_Name}", Resultat = s.Year_Result };

foreach (var s in result_3_5)
{
    Console.WriteLine($"{s.NomComplet} {s.Resultat}");
}
*/

/*3.6*/
/*Exercice 3.6 Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel
classé par ordre croissant sur la section de tous les étudiants appartenant aux sections 1010
et 1020 ayant un résultat annuel qui n’est pas compris entre 12 et 18.*/
/*
//var result_3_6 = dc.Students.Where(s => (s.Section_ID == 1010 || s.Section_ID == 1020) && (s.Year_Result < 12 || s.Year_Result > 18))
//                            .OrderBy(s => s.Section_ID)
//                            .Select(s => new {s.Last_Name, s.Section_ID, s.Year_Result});

var result_3_6 = from Student s in dc.Students
                 where (s.Section_ID == 1010 || s.Section_ID == 1020) && (s.Year_Result < 12 || s.Year_Result > 18)
                 orderby s.Section_ID
                 select new { s.Last_Name, s.Section_ID, s.Year_Result };

foreach (var s in result_3_6)
{
    Console.WriteLine($"{s.Last_Name} {s.Section_ID} {s.Year_Result}");
}
*/

/*3.7*/
/* Exercice 3.7 Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur
100 (nommer la colonne ‘result_100’) classé par ordre décroissant du résultat de tous les
étudiants appartenant aux sections commençant par 13 et ayant un résultat annuel sur 100
inférieur ou égal à 60.*/
/*
//var result_3_7 = dc.Students.Where(s => s.Section_ID.ToString().StartsWith("13") && s.Year_Result * 5 <= 60)
//                            .OrderByDescending(s => s.Year_Result)
//                            .Select(s => new { s.Last_Name, s.Section_ID, Result_100 = s.Year_Result * 5 });
//var result_3_7 = dc.Students.Where(s => s.Section_ID.ToString().StartsWith("13") && s.Year_Result * 5 <= 60)
//                            .Select(s => new { s.Last_Name, s.Section_ID, Result_100 = s.Year_Result * 5 })
//                            .OrderByDescending(s => s.Result_100);
var result_3_7 = from Student s in dc.Students
                 where s.Section_ID.ToString().StartsWith("13") && s.Year_Result * 5 <= 60
                 orderby s.Year_Result descending
                 select new { s.Last_Name, s.Section_ID, Result_100 = s.Year_Result * 5 };

foreach (var s in result_3_7)
{
    Console.WriteLine($"{s.Last_Name} {s.Section_ID} {s.Result_100}");
}
*/

/*4.1*/
/*Exercice 4.1 Donner le résultat annuel moyen pour l’ensemble des étudiants.*/
/*
double result_4_1 = dc.Students.Average(s => s.Year_Result);

//double result_4_1 = dc.Students.Select(s => s.Year_Result).Average();

//double result_4_1 = (from Student s in dc.Students
//                    select s.Year_Result).Average();

Console.WriteLine(result_4_1);
*/

/*4.2*/
/*Exercice 4.2 Donner le plus haut résultat annuel obtenu par un étudiant.*/
/*
int result_4_2 = dc.Students.Max(s => s.Year_Result);

Console.WriteLine(result_4_2);
*/

/*4.3*/
/*Exercice 4.3 Donner la somme des résultats annuels.*/
/*
int result_4_3 = dc.Students.Sum(s => s.Year_Result);

Console.WriteLine(result_4_3);
*/

/*4.4*/
/*Exercice 4.4 Donner le résultat annuel le plus faible.*/
/*
int result_4_4 = dc.Students.Min(s => s.Year_Result);

Console.WriteLine(result_4_4);
*/

/*4.5*/
/*Exercice 4.5 Donner le nombre de lignes qui composent la séquence « Students » ayant obtenu
un résultat annuel impair.*/
/*
//int result_4_5 = dc.Students.Count(s => s.Year_Result % 2 != 0);

int result_4_5 = (from Student s in dc.Students
                 select s).Count(s => s.Year_Result % 2 != 0);

Console.WriteLine(result_4_5);
*/

/*5.1*/
/*Exercice 5.1 Donner pour chaque section, le résultat maximum (« Max_Result ») obtenu par les
étudiants.*/
/*
//var result_5_1 = dc.Students.GroupBy(s => s.Section_ID).Select(g => new { SectionId = g.Key, MaxResult = g.Max(s => s.Year_Result)});

//IEnumerable<IGrouping<int, Student>> result_5_1 = dc.Students.GroupBy(s => s.Section_ID);

//foreach(IGrouping<int,Student> result in result_5_1)
//{
//    Console.WriteLine($"{result.Key} {result.Max(s => s.Year_Result)}");
//}

var result_5_1 = from Student s in dc.Students
                 group s by s.Section_ID into StudentSection
                 select new { SectionId = StudentSection.Key, MaxResult = StudentSection.Max(s => s.Year_Result) };

foreach (var s in result_5_1)
{
    Console.WriteLine($"{s.SectionId} {s.MaxResult}");
}
*/

/*5.2*/
/*Exercice 5.2 Donner pour toutes les sections commençant par 10, le résultat annuel moyen
(« AVGResult ») obtenu par les étudiants.*/
/*
//var result_5_2 = dc.Students.Where(s => s.Section_ID.ToString().StartsWith("10"))
//                            .GroupBy(s => s.Section_ID)
//                            .Select(g => new { Sectionid = g.Key, Moyenne = g.Average(s => s.Year_Result) });

var result_5_2 = from Student s in dc.Students
                 where s.Section_ID.ToString().StartsWith("10")
                 group s by s.Section_ID into groupStudent
                 select new { Sectionid = groupStudent.Key, Moyenne = groupStudent.Average(s => s.Year_Result) };

foreach (var s in result_5_2)
{
    Console.WriteLine($"{s.Sectionid} {s.Moyenne}");
}
*/
/*5.3*/
/*Exercice 5.3 Donner le résultat moyen (« AVGResult ») et le mois en chiffre (« BirthMonth »)
pour les étudiants né le même mois entre 1970 et 1985.*/
/*
//var result_5_3 = dc.Students.Where(s => s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985)
//                            .GroupBy(s => s.BirthDate.Month)
//                            .Select(s => new { BirthMonth = s.Key, AVGResult = s.Average(s => s.Year_Result) });

var result_5_3 = from Student s in dc.Students
                 where s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985
                 group s by s.BirthDate.Month into student
                 select new { BirthMonth = student.Key, AVGResult = student.Average(s => s.Year_Result) };

foreach(var s in result_5_3)
{
    Console.WriteLine($"Mois : {s.BirthMonth} | Moyenne : {s.AVGResult}");
}
*/
/*5.4*/
/*Exercice 5.4 Donner pour toutes les sections qui compte plus de 3 étudiants, la moyenne des
résultats annuels (« AVGResult »)*/
/*
//var result_5_4 = dc.Students.GroupBy(s => s.Section_ID)
//                            .Where(g => g.Count() > 3)
//                            .Select(g => new { SectionId = g.Key, Moyenne = g.Average(s => s.Year_Result) });

var result_5_4 = from Student s in dc.Students
                 group s by s.Section_ID into g
                 where g.Count() > 3
                 select new { SectionId = g.Key, Moyenne = g.Average(s => s.Year_Result) };

foreach (var s in result_5_4)
{
    Console.WriteLine($"{s.SectionId} {s.Moyenne}");
}
*/
/*5.5*/
/*Exercice 5.5 Donner pour chaque cours, le nom du professeur responsable ainsi que la section
dont le professeur fait partie.*/
/*
var result_5_5 = dc.Courses.Join(dc.Professors,
                                 c => c.Professor_ID,
                                 p => p.Professor_ID,
                                 (c, p) => new
                                 {
                                     Course = c,
                                     Professor = p
                                 }).Join(dc.Sections,
                                         cp => cp.Professor.Section_ID,
                                         s => s.Section_ID,
                                         (cp, s) => new
                                         {
                                             cp.Course.Course_Name,
                                             s.Section_Name,
                                             cp.Professor.Professor_Name
                                         });

//var result_5_5 = from c in dc.Courses
//                 join p in dc.Professors on c.Professor_ID equals p.Professor_ID
//                 join s in dc.Sections on p.Section_ID equals s.Section_ID
//                 select new { c.Course_Name, s.Section_Name, p.Professor_Name };

foreach (var i in result_5_5)
{
    Console.WriteLine($"{i.Course_Name} {i.Section_Name} {i.Professor_Name}");
}
*/
/*5.6*/
/*Exercice 5.6 Donner pour chaque section, l’id, le nom et le nom de son délégué. Classer les
sections dans l’ordre inverse des id de section.*/
/*
var result_5_6 = dc.Sections.Join(dc.Students,
                                  se => se.Delegate_ID,
                                  st => st.Student_ID, 
                                  (se, st) => new { se.Section_ID, se.Section_Name, Delegate_Last_Name = st.Last_Name })
                             .OrderByDescending(jointure => jointure.Section_ID);

var result_5_6 = from se in dc.Sections
                 join st in dc.Students on se.Delegate_ID equals st.Student_ID
                 orderby se.Section_ID descending
                 select new { se.Section_ID, se.Section_Name, Delegate_Last_Name = st.Last_Name };


foreach (var r in result_5_6)
{
    Console.WriteLine($"{r.Section_ID} {r.Section_Name} {r.Delegate_Last_Name}");
}
*/
/*5.7*/
/*Exercice 5.7 Donner, pour toutes les sections, le nom des professeurs qui en sont membres*/
/*
var result_5_7 = dc.Sections.GroupJoin(dc.Professors,
                                       se => se.Section_ID,
                                       p => p.Section_ID,
                                       (se, SubProfs) => new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) });

//var result_5_7 = from se in dc.Sections
//                 join p in dc.Professors on se.Section_ID equals p.Section_ID into SubProfs
//                 select new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) };

foreach (var r in result_5_7)
{
    Console.WriteLine($"{r.Section_ID} - {r.Section_Name}");
    foreach (string p_name in r.Professors)
    {
        Console.WriteLine($"- {p_name}");
    }
}
*/
/*5.8*/
/*Exercice 5.8 Même objectif que la question 5.7, mais seules les sections comportant au moins
un professeur doivent être reprises.*/
/*
var result_5_8 = dc.Sections.GroupJoin(dc.Professors,
                                       se => se.Section_ID,
                                       p => p.Section_ID,
                                       (se, SubProfs) => new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) })
                            .Where(Jointure => Jointure.Professors.Count() > 0);

//var result_5_8 = from se in dc.Sections
//                 join p in dc.Professors on se.Section_ID equals p.Section_ID into SubProfs
//                 where SubProfs.Count() > 0
//                 select new { se.Section_ID, se.Section_Name, Professors = SubProfs.Select(pr => pr.Professor_Name) };

foreach (var r in result_5_8)
{
    Console.WriteLine($"{r.Section_ID} - {r.Section_Name}");
    foreach (string p_name in r.Professors)
    {
        Console.WriteLine($"- {p_name}");
    }
}
*/
/*5.9*/
/*Exercice 5.9 Donner à chaque étudiant ayant obtenu un résultat annuel supérieur ou égal à 12
son grade en fonction de son résultat annuel et sur base de la table grade. La liste doit être
classée dans l’ordre alphabétique des grades attribués.*/
/*
var result_5_9 = dc.Students.Join(dc.Grades,
                                   st => true,
                                   gr => true,
                                   (st, grade) => new { Student = st, Grade = grade })
                             .Where(join => join.Student.Year_Result >= 12 && join.Student.Year_Result >= join.Grade.Lower_Bound && join.Student.Year_Result <= join.Grade.Upper_Bound)
                             .Select(join => new { join.Student.Last_Name, join.Student.Year_Result, Grade = join.Grade.GradeName })
                             .OrderBy(elt => elt.Grade);

//var result_5_9 = from s in dc.Students
//                 from g in dc.Grades
//                 where s.Year_Result >= 12 && s.Year_Result >= g.Lower_Bound && s.Year_Result <= g.Upper_Bound
//                 orderby g.GradeName
//                 select new { s.Last_Name, s.Year_Result, Grade = g.GradeName };

foreach (var r in result_5_9)
{
    Console.WriteLine($"{r.Last_Name} - {r.Year_Result} - {r.Grade}");
}
*/
/*5.10*/
/*Exercice 5.10 Donner la liste des professeurs et la section à laquelle ils se rapportent ainsi que
le(s) cour(s) (nom du cours et crédits) dont le professeur est responsable. La liste est triée
par ordre décroissant des crédits attribués à un cours*/
/*
var result_5_10 = dc.Professors.GroupJoin(dc.Courses,
                                          p => p.Professor_ID,
                                          c => c.Professor_ID, 
                                          (p, cs) => new { Professor = p, Courses = cs })
                               .SelectMany(r => r.Courses.DefaultIfEmpty(), (pc, c) => new { Professor = pc.Professor, Course = c })
                               .GroupJoin(dc.Sections,
                                          p => p.Professor.Section_ID,
                                          s => s.Section_ID, 
                                          (pc, s) => new { Professor = pc.Professor, Course = pc.Course, Sections = s })
                               .SelectMany(r => r.Sections.DefaultIfEmpty(), (pcs, s) => new { Professor = pcs.Professor, Course = pcs.Course, Section = s })
                               .Select(pcs => new
                               {
                                   pcs.Professor.Professor_Name,
                                   Section_Name = (pcs.Section != null) ? pcs.Section.Section_Name : null,
                                   Course_Name = (pcs.Course != null) ? pcs.Course.Course_Name : null,
                                   Course_Ects = (pcs.Course != null) ? (float?)pcs.Course.Course_Ects : null
                               })
                               .OrderByDescending(r => r.Course_Ects)
                               .Select(r => new
                               {
                                   r.Professor_Name,
                                   Section_Name = (r.Section_Name != null) ? r.Section_Name : "NULL",
                                   Course_Name = (r.Course_Name != null) ? r.Course_Name : "NULL",
                                   Course_Ects = (r.Course_Ects != null) ? r.Course_Ects.ToString() : "NULL"
                               });

//var result_5_10 = from p in dc.Professors
//                  join c in dc.Courses on p.Professor_ID equals c.Professor_ID into SubCourses
//                  from sc in SubCourses.DefaultIfEmpty()
//                  join s in dc.Sections on p.Section_ID equals s.Section_ID into SubSections
//                  from ss in SubSections.DefaultIfEmpty()
//                  select new
//                  {
//                      p.Professor_Name,
//                      Section_Name = (ss != null) ? ss.Section_Name : null,
//                      Course_Name = (sc != null) ? sc.Course_Name : null,
//                      Course_Ects = (sc != null) ? (float?)sc.Course_Ects : null
//                  } into SubResult
//                  orderby SubResult.Course_Ects descending
//                  select new
//                  {
//                      SubResult.Professor_Name,
//                      Section_Name = (SubResult.Section_Name != null) ? SubResult.Section_Name : "Null",
//                      Course_Name = (SubResult.Course_Name != null) ? SubResult.Course_Name : "Null",
//                      Course_Ects = (SubResult.Course_Ects != null) ? SubResult.Course_Ects.ToString() : "Null"
//                  };

foreach (var r in result_5_10)
{
    Console.WriteLine($"{r.Professor_Name} - {r.Section_Name} - {r.Course_Name} - {r.Course_Ects}");
}
*/
/*5.11*/
/*Exercice 5.11 Donner pour chaque professeur son id et le total des crédits ECTS
(« ECTSTOT ») qui lui sont attribués. La liste proposée est triée par ordre décroissant de la
somme des crédits alloués.*/
/*
var result_5_11 = dc.Professors.GroupJoin(dc.Courses, 
                                           p => p.Professor_ID,
                                           c => c.Professor_ID,
                                           (p, SubCourses) => new { p.Professor_ID, Course_Ects = (SubCourses.Count() > 0) ? (float?)SubCourses.Sum(co => co.Course_Ects) : null })
                                .OrderByDescending(r => r.Course_Ects);

//var result_5_11 = from p in dc.Professors
//                  join c in dc.Courses on p.Professor_ID equals c.Professor_ID into SubCourses
//                  orderby SubCourses.Sum(c => c.Course_Ects) descending
//                  select new { p.Professor_ID, Course_Ects = (SubCourses.Count() > 0) ? (float?)SubCourses.Sum(co => co.Course_Ects) : null };

foreach (var r in result_5_11)
{
    Console.WriteLine($"{r.Professor_ID} - {r.Course_Ects}");
}
*/
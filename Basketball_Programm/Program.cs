// See https://aka.ms/new-console-template for more information

using global::System;


using global::chen0040.ExpertSystem;
using global::Microsoft.ML.Probabilistic.Models;
using Rule = global::chen0040.ExpertSystem.Rule;
using RuleInferenceEngine = chen0040.ExpertSystem.RuleInferenceEngine;

var inferenceEngine=new RuleInferenceEngine();



var rule = new Rule("Наличие учебных занятий");
rule.AddAntecedent(new GreaterClause("занятия","нет"));
rule.setConsequent(new IsClause("выходной день","да"));


inferenceEngine.AddRule(rule);
rule=new Rule("Погода на улице");
rule.AddAntecedent(new IsClause("солнечно","да"));
rule.setConsequent(new IsClause("хорошая погода для занятия баскетболом","да"));
inferenceEngine.AddRule(rule);


inferenceEngine.AddRule(rule);
rule=new Rule("Компания");
rule.AddAntecedent(new IsClause("друзья","да"));
rule.setConsequent(new IsClause("есть команда","да"));

inferenceEngine.AddRule(rule);
rule=new Rule("Настрой");
rule.AddAntecedent(new IsClause("настроение","тренировочное"));
rule.setConsequent(new IsClause("настрой ","боевой"));

inferenceEngine.AddRule(rule);
rule=new Rule("Решение об занятие баскетболом сегодня"); 
rule.AddAntecedent(new IsClause("друзья","нет"));
rule.AddAntecedent(new IsClause("настроение","тренировочное"));
rule.setConsequent(new IsClause("тренируемся в одиночестве","да"));


inferenceEngine.AddRule(rule);
rule=new Rule("Здоровье");
rule.AddAntecedent(new IsClause("самочувствие","хорошее"));
rule.setConsequent(new IsClause("вы здоровы","да"));


inferenceEngine.AddRule(rule);
rule=new Rule("Площадка для игры");
rule.AddAntecedent(new IsClause("место","спортзал"));
rule.setConsequent(new IsClause("играем под крышей","да"));




inferenceEngine.AddRule(rule);
rule=new Rule("Решение об занятие баскетболом сегодня");
rule.AddAntecedent(new IsClause("занятия","нет"));
rule.AddAntecedent(new IsClause("солнечно","да"));
rule.AddAntecedent(new IsClause("друзья","да"));
rule.AddAntecedent(new IsClause("самочувствие","хорошее"));
rule.setConsequent(new IsClause("баскетбол","да!"));
inferenceEngine.AddRule(rule);

inferenceEngine.AddRule(rule);
rule=new Rule("Решение об занятие баскетболом сегодня");
rule.AddAntecedent(new IsClause("занятия","нет"));
rule.AddAntecedent(new IsClause("солнечно","да"));
rule.AddAntecedent(new IsClause("друзья","нет"));
rule.AddAntecedent(new IsClause("настроение","тренировочное"));
rule.AddAntecedent(new IsClause("самочувствие","хорошее"));
rule.setConsequent(new IsClause("баскетбол","да!"));
inferenceEngine.AddRule(rule);



inferenceEngine.AddRule(rule);
rule=new Rule("Решение об занятие баскетболом сегодня");
rule.AddAntecedent(new IsClause("занятия","нет"));
rule.AddAntecedent(new IsClause("солнечно","нет"));
rule.AddAntecedent(new IsClause("место","спортзал"));
rule.AddAntecedent(new IsClause("друзья","да"));
rule.AddAntecedent(new IsClause("самочувствие","хорошее"));
rule.setConsequent(new IsClause("баскетбол","да!"));
inferenceEngine.AddRule(rule);



  
inferenceEngine.AddFact(new IsClause("занятия", "нет"));
inferenceEngine.AddFact(new IsClause("солнечно", "да"));
inferenceEngine.AddFact(new IsClause("место", "спортзал"));
inferenceEngine.AddFact(new IsClause("настроение", "тренировочное"));
inferenceEngine.AddFact(new IsClause("друзья", "нет"));
inferenceEngine.AddFact(new IsClause("самочувствие", "хорошее"));
inferenceEngine.Infer();
Console.WriteLine("Все факты:");
Console.WriteLine(inferenceEngine.Facts);


var conclusion = inferenceEngine.Facts.IsFact(new IsClause("баскетбол", "да"));
Console.WriteLine("Вывод:");
Console.WriteLine(conclusion ? "Прекрасный день для игры в баскетбол":"Сегодня не лучший день чтобы играть в баскетбол.Не играем.");
# Testes de Tipos de Serviço de Injeção de Dependência para GuidService

Este repositório contém testes unitários para verificar o comportamento dos diferentes tipos de serviço de injeção de dependência para a classe `GuidService`. Os tipos de serviço testados são Scoped, Singleton e Transient.

## Testes Implementados

### AddScoped_Should_Equal_OnlyInSameScope

Este teste verifica se o serviço registrado como Scoped tem o mesmo valor apenas dentro do mesmo escopo.

### AddSingleton_Should_Equal_InAllLifeTime

Este teste verifica se o serviço registrado como Singleton tem o mesmo valor durante todo o seu ciclo de vida.

### AddTransient_Should_NotEqual_Ever

Este teste verifica se o serviço registrado como Transient nunca tem o mesmo valor, independentemente do escopo ou do ciclo de vida.


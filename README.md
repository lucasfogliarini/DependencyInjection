# Testes de Tipos de Servi�o de Inje��o de Depend�ncia para GuidService

Este reposit�rio cont�m testes unit�rios para verificar o comportamento dos diferentes tipos de servi�o de inje��o de depend�ncia para a classe `GuidService`. Os tipos de servi�o testados s�o Scoped, Singleton e Transient.

## Testes Implementados

### AddScoped_Should_Equal_OnlyInSameScope

Este teste verifica se o servi�o registrado como Scoped tem o mesmo valor apenas dentro do mesmo escopo.

### AddSingleton_Should_Equal_InAllLifeTime

Este teste verifica se o servi�o registrado como Singleton tem o mesmo valor durante todo o seu ciclo de vida.

### AddTransient_Should_NotEqual_Ever

Este teste verifica se o servi�o registrado como Transient nunca tem o mesmo valor, independentemente do escopo ou do ciclo de vida.


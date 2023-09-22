﻿namespace General.Models;

/// <summary xml:lang = "ru">
/// Контракт для сущности, которая может быть не полностью загружена.
/// </summary>
public interface ILoadable
{
    /// <summary xml:lang = "ru">
    /// Флаг - была ли полностью произведена загрузка.
    /// </summary>
    public bool IsLoaded { get; }
}

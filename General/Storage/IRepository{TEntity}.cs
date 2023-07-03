﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Storage;

/// <summary xml:lang="ru">
/// Описывает репозиторий сущностей.
/// </summary>
/// <typeparam name="TEntity">Тип сущности репозитория.</typeparam>
public interface IRepository<TEntity>
{
    /// <summary xml:lang = "ru">
    /// Возвращает коллекцию сущностей, находящихся в репозитории.
    /// </summary>
    /// <returns xml:lang = "ru">
    /// Коллекция типа <see cref="IQueryable{T}"/>.
    /// </returns>
    public IEnumerable<TEntity> GetEntities();

    /// <summary xml:lang = "ru">
    /// Определяет, находится ли данная сущность в репозитории.
    /// </summary>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность.
    /// </param>
    /// <param name="token" xml:lang = "ru">
    /// Токен отмены.
    /// </param>
    /// <returns xml:lang = "ru">
    /// <see langword="true"/>, если сущность есть в репозитории, иначе - <see langword="false"/>.
    /// </returns>
    public Task<bool> ContainsAsync(TEntity entity, CancellationToken token = default);

    /// <summary xml:lang = "ru">
    /// Добавляет сущность в репозиторий.
    /// </summary>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность.
    /// </param>
    /// <param name="token" xml:lang = "ru">
    /// Токен отмены.
    /// </param>
    /// <returns xml:lang = "ru">
    /// <see cref="Task"/>.
    /// </returns>
    public Task AddAsync(TEntity entity, CancellationToken token = default);

    /// <summary xml:lang = "ru">
    /// Удаляет сущность из репозитория.
    /// </summary>
    /// <param name="entity" xml:lang = "ru">
    /// Сущность.
    /// </param>
    public void Delete(TEntity entity);

    /// <summary xml:lang = "ru">
    /// Сохраняет все накопленные команды.
    /// </summary>
    /// <returns xml:lang = "ru">
    /// <see cref="Task"/>.
    /// </returns>
    public void Save();
}
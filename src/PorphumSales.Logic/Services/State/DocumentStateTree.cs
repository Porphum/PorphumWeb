﻿using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Services.State;

public static class DocumentStateTree
{
    public static Dictionary<DocumentState, HashSet<DocumentState>> Transictions = new()
    {
        { DocumentState.Init, new() { DocumentState.Fill, DocumentState.Complete } },
        { DocumentState.Fill, new() { DocumentState.Complete } },
    };
}

namespace TrabalhoFerramentas.Metodos.Utils;

public static class SigmaUtils
{
    private static readonly HashSet<char> Sigma = new() { 'a', 'b' };

    public static bool CadeiaEmSigma(string? cadeia)
    {
        if (cadeia is null) return false;
        foreach (var ch in cadeia)
            if (!Sigma.Contains(char.ToLowerInvariant(ch))) return false;
        return true;
    }

    public static bool SimboloEmSigma(string? s)
    {
        if (string.IsNullOrWhiteSpace(s)) return false;
        var t = s.Trim();
        return t.Length == 1 && Sigma.Contains(char.ToLowerInvariant(t[0]));
    }
}

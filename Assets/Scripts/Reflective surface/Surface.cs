

class Surface : ISurface
{
    private readonly float absorptionCoefficient;
    
    public float AbsorptionCoefficient => absorptionCoefficient;

    public Surface(float absorptionCoefficient)
    {
        this.absorptionCoefficient = absorptionCoefficient;
    }
    
}
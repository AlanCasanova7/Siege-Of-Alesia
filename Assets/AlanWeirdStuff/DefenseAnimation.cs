using UnityEngine;

public class DefenseAnimation : AttackAnimation
{
    public Vector3 offset;
    public float size;
    public int numberOfPositions;

    public bool GeneratePoints = false;

    protected override void Start()
    {
        this.enabled = false;
        this.populationManager = this.GetComponentInChildren<PopulationManager>();
    }

    public override void FinalAnimation()
    {
        if (!endAnim)
            return;
        populationManager.Freeze();
        base.FinalAnimation();
    }

    private void OnValidate()
    {
        if (GeneratePoints)
        {
            regroupPositions = new Vector3[0];

            regroupPositions = new Vector3[1];
            if (RegroupPoints.Length == 0)
            {
                return;
            }
            for (int i = 0; i < RegroupPoints.Length; i++)
            {
                regroupPositions[i] = RegroupPoints[i].position;
            }


            Vector3 startingPoint = this.regroupPositions[0] - new Vector3(0, size * 0.5f, size * 0.5f) + this.offset;
            float spacing = size / numberOfPositions;

            Vector3[] customVectors = new Vector3[numberOfPositions * numberOfPositions];
            for (int i = 0; i < numberOfPositions; i++)
            {
                for (int j = 0; j < numberOfPositions; j++)
                {
                    Vector3 v = new Vector3(startingPoint.x, startingPoint.y + (i * spacing), startingPoint.z + (j * spacing));
                    customVectors[(i * numberOfPositions) + j] = v;
                }
            }

            regroupPositions = customVectors;

            GeneratePoints = false;
        }
    }
}


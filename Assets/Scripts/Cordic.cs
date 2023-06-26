using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cordic : MonoBehaviour
{
    [SerializeField] private CordicInputs cordicInputs;
    [SerializeField] private CameraController cameraController;

    [SerializeField] private CordicBlock cordicBlockPrefab;
    [SerializeField] private Vector3 cordicBlockOffset;

    private CordicBlock[] cordicBlocks = new CordicBlock[0];
    

    [ContextMenu("UpdateBlock")]
    private void UpdateBlock()
    {
        int itrationCount = cordicInputs.itrationCount;
        

        if (itrationCount != cordicBlocks.Length)
        {
            if(cordicBlocks.Length != 0)
                DestroyBlocks();
            GenerateBlocks(itrationCount);
        }

        cameraController.SetMinY(cordicBlockOffset.y * (cordicBlocks.Length));

        Propagate();
    }

    public void Propagate()
    {
        var mode = cordicInputs.mode;
        var mu = cordicInputs.mu;
        var itrationCount = cordicInputs.itrationCount;


        double lastXValue = cordicInputs.x;
        double lastYValue = cordicInputs.y;
        double lastZValue = cordicInputs.z;
        foreach (var cordicBlock in cordicBlocks)
        {
            cordicBlock.Initialize(mode, mu);
            cordicBlock.InputLines.lineX.SetValue(lastXValue);
            cordicBlock.InputLines.lineY.SetValue(lastYValue);
            cordicBlock.InputLines.lineZ.SetValue(lastZValue);
            cordicBlock.Propagate();

            lastXValue = cordicBlock.OutputLines.lineX.Value;
            lastYValue = cordicBlock.OutputLines.lineY.Value;
            lastZValue = cordicBlock.OutputLines.lineZ.Value;
        }
    }
    private void DestroyBlocks()
    {
        for (uint i = 0; i < cordicBlocks.Length; i++)
        {
            Destroy(cordicBlocks[i].gameObject);
        }
    }
    private void GenerateBlocks(int itrationCount)
    {
        if(cordicInputs.mu != -1)
        {
            cordicBlocks = new CordicBlock[itrationCount + 1];
            var spawnPosition = Vector3.zero;
            for (uint i = 0; i <= itrationCount; i++)
            {
                var clone = Instantiate<CordicBlock>(cordicBlockPrefab, spawnPosition, Quaternion.identity);
                clone.Initialize(i, i == itrationCount);
                cordicBlocks[i] = clone;
                spawnPosition += cordicBlockOffset;
            }

        }
        else
        {
            List<CordicBlock> cordicBlocksList = new List<CordicBlock>(itrationCount + 1);
            var spawnPosition = Vector3.zero;

            for (uint i = 0; i <= itrationCount; i++)
            {
                var clone = Instantiate<CordicBlock>(cordicBlockPrefab, spawnPosition, Quaternion.identity);
                clone.Initialize(i, i == itrationCount);
                cordicBlocksList.Add(clone);
                spawnPosition += cordicBlockOffset;
                if(i == 3 || i == 12 || i == 39 || i == 120 || i == 363)
                {
                    clone = Instantiate<CordicBlock>(cordicBlockPrefab, spawnPosition, Quaternion.identity);
                    clone.Initialize(i, i == itrationCount);
                    cordicBlocksList.Add(clone);
                    spawnPosition += cordicBlockOffset;
                }
            }

            cordicBlocks = cordicBlocksList.ToArray();
        }

        
    }

}

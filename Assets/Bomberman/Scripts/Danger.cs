﻿
using UnityEngine;
using System.Collections;

/// <summary>
/// Small script for easily destroying an object after a while
/// </summary>
public class Danger : MonoBehaviour
{
    //public int scenarioId;
    public Bomb myBomb = null;
    public ulong id;

    public Grid grid;
    private StateType stateType;

    private float dangerLevelOfPosition;
    //private float timePassed;

    public int discrete_timer = 0;

    private void Awake()
    {
        stateType = StateType.ST_Danger;
        discrete_timer = 0;
        dangerLevelOfPosition = (float)discrete_timer / (float)Config.BOMB_TIMER_DISCRETE;
    }

    public bool iterationUpdate()
    {
        discrete_timer += 1;

        dangerLevelOfPosition = (float)discrete_timer / (float)Config.BOMB_TIMER_DISCRETE;

        if (discrete_timer >= Config.BOMB_TIMER_DISCRETE)
        {
            return myDestroy();
        }

        return false;
    }

    /*private void FixedUpdate()
    {
        timePassed += Time.fixedDeltaTime;

        if (timePassed > Config.BOMB_TIMER)
        {
            timePassed = Config.BOMB_TIMER;
        }

        dangerLevelOfPosition = timePassed / Config.BOMB_TIMER;
    }*/

    public float GetDangerLevelOfPosition(Player player)
    {
        //penalty The danger value is negative if the bomb has been placed by the player and positive if it has been placed by an opponent(or environment)
        float penalty = 1.0f;
        if (myBomb.bomberman != null)
        {
            penalty = myBomb.bomberman.getPlayerNumber() == player.getPlayerNumber() ? -1.0f : 1.0f;
        }
        
        return dangerLevelOfPosition * penalty;
    }

    public string GetDangerLevelOfPositionToPrint()
    {
        return (dangerLevelOfPosition * -1.0f).ToString("0.000");
    }

    public Vector2 GetGridPosition()
    {
        BinaryNode n = grid.NodeFromWorldPoint(transform.localPosition);
        return new Vector2(n.gridX, n.gridY);
    }

    public void forceDestroy()
    {
        grid.disableObjectOnGrid(stateType, GetGridPosition());
        Destroy(gameObject);
    }

    bool myDestroy()
    {
        forceDestroy();
        return true;
    }
}

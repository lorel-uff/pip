﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BinaryNode : BaseNode {

    private StateType binary;

    public int getBinary()
    {
        return (int)binary;
    }

    public string getStringBinaryArray()
    {
        string s = StateTypeExtension.getIntBinaryString(binary);

        return s;
    }

    public int getFreeBreakableObstructedCell()
    {
        if (hasFlag(StateType.ST_Wall) || hasFlag(StateType.ST_Bomb))
        {
            return -1;
        }
        else if (hasFlag(StateType.ST_Block))
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public int getFreeCell()
    {
        if (hasFlag(StateType.ST_Wall) || hasFlag(StateType.ST_Bomb) || hasFlag(StateType.ST_Block))
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    /*public int getPositionTarget()
    {
        if (hasFlag(StateType.ST_Target))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }*/

    public bool getDangerPosition()
    {
        if (hasFlag(StateType.ST_Danger))
            return true;

        return false;
    }

    public void addFlags(List<StateType> flags)
    {
        for (int i = 0; i < flags.Count; ++i)
            addFlag(flags[i]);
    }

    public void addFlag(StateType stateType)
    {
        if (StateTypeExtension.existsFlag(stateType))
        {
            binary = binary | stateType;
        }
    }

    public void removeFlag(StateType stateType)
    {
        if (StateTypeExtension.existsFlag(stateType))
        {
            binary = binary & (~stateType);
        }
    }

    public void clearAllFlags()
    {
        binary = StateType.ST_Empty;
    }

    public bool hasFlag(StateType stateType)
    {
        if (stateType != StateType.ST_Empty)
        {
            if (StateTypeExtension.existsFlag(stateType))
            {
                return ((binary & stateType) == stateType ? true : false);
            }
        }
        else
        {
            if (binary == stateType)
                return true;
        }
        return false;
    }

    //função não testa ST_Empty
    public bool hasSomeFlag(StateType flags)
    {
        if (StateTypeExtension.existsFlag(flags))
        {
            return ((binary & flags) != 0 ? true : false);
        }
        
        return false;
    }

    public BinaryNode(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY, int _penalty, List<StateType> stateTypes)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
        movementPenalty = _penalty;

        addFlags(stateTypes);

        cost = _penalty;
    }
}

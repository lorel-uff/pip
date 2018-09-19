﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config {

    //Recompensas
    public static float REWARD_DIE = -1f;
    public static float REWARD_KILL_FRIEND = -1f;

    public static float REWARD_GOAL = 1f;
    public static float REWARD_TEAM_GOAL = 1f;


    public static float REWARD_BLOCK_DESTROY = 0.51f;
    public static float REWARD_CLOSEST_DISTANCE = 0.51f;
    public static float REWARD_APPROACHED_DISTANCE = 0.007625f;
    public static float REWARD_FAR_DISTANCE = -0.007625f;
    public static float REWARD_TIME_PENALTY = -0.001f;

    public static float REWARD_STOP_ACTION = -0.03f;

    public static float REWARD_INVALID_WALK_ACTION = -0.02f;
    public static float REWARD_VALID_WALK_ACTION = 0.02f;

    public static float REWARD_INVALID_HAMMER_ACTION = -0.02f;
    public static float REWARD_VALID_HAMMER_ACTION = 0.02f;

    public static float REWARD_INVALID_BOMB_ACTION = -0.02f;

    public static float REWARD_MAX_STEP_REACHED = -1.0f;

    public static float REWARD_CORRECT_TEACHER_ACTION = 0.6f;
    public static float REWARD_WRONG_TEACHER_ACTION = -0.6f;

    //Max step per agent
    public static int MAX_STEP_PER_AGENT = 150;

    //tempo para a bomba explodir (contínuo)
    public static float BOMB_TIMER = 3.0f;
    //tempo para a bomba sumir após explodir
    public static float BOMB_TIMER_AFTER_DESTROY = 0.3f;
    //tempo para o fogo da explosão sumir após explosão
    public static float EXPLOSION_TIMER = 0.55f;
    public static float EXPLOSION_TIMER_DISCRETE = 2;
    //tempo para a bomba explodir (discreto). Número de iterações
    public static int BOMB_TIMER_DISCRETE = 6;
}

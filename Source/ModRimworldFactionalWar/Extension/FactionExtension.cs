﻿// ******************************************************************
//       /\ /|       @file       FactionExtension.cs
//       \ V/        @brief      派系扩展
//       | "")       @author     Shadowrabbit, yingtu0401@gmail.com
//       /  |                    
//      /  \\        @Modified   2021-06-17 21:32:27
//    *(__\_\        @Copyright  Copyright (c) 2021, Shadowrabbit
// ******************************************************************
using RimWorld;
using Verse;

namespace SR.ModRimWorld.FactionalWar
{
    public static class FactionExtension
    {
        /// <summary>
        /// 派系是否有效
        /// </summary>
        /// <param name="faction">派系</param>
        /// <param name="points">事件点数</param>
        /// <param name="pawnGroupKindDef">角色组类型定义</param>
        /// <returns></returns>
        public static bool IsFactionEffective(this Faction faction, float points, PawnGroupKindDef pawnGroupKindDef)
        {
            //派系是临时的
            if (faction.temporary)
            {
                return false;
            }

            //派系被打败了
            if (faction.defeated)
            {
                return false;
            }

            //派系不是人类派系
            if (!faction.def.humanlikeFaction)
            {
                return false;
            }

            //派系没有角色组制作器
            if (faction.def.pawnGroupMakers == null)
            {
                return false;
            }

            //派系角色组中没有类型
            if (!faction.def.pawnGroupMakers.Any(
                x => x.kindDef == pawnGroupKindDef))
            {
                return false;
            }

            //袭击点数不足以生成组
            return points >= faction.def.MinPointsToGeneratePawnGroup(pawnGroupKindDef);
        }
    }
}
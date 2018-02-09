﻿// *****************************************************************************
// BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
//  © Component Factory Pty Ltd, 2006-2018, All rights reserved.
// The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to licence terms.
// 
//  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV) 2017 - 2018. All rights reserved. (https://github.com/Wagnerp/Krypton-NET-4.60)
//  Version 4.60.0.0  www.ComponentFactory.com
// *****************************************************************************

using System.Drawing;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit
{
	/// <summary>
	/// Inherit properties from primary source in preference to the backup source.
	/// </summary>
	public class PaletteBorderInheritOverride : PaletteBorderInherit
	{
		#region Instance Fields

	    private IPaletteBorder _primary;
		private IPaletteBorder _backup;
		#endregion

		#region Identity
		/// <summary>
		/// Initialize a new instance of the PaletteBorderInheritOverride class.
		/// </summary>
		/// <param name="primary">First choice inheritence.</param>
		/// <param name="backup">Backup inheritence.</param>
		public PaletteBorderInheritOverride(IPaletteBorder primary,
										    IPaletteBorder backup)
		{
			Debug.Assert(primary != null);
			Debug.Assert(backup != null);

			// Store incoming alternatives
			_primary = primary;
			_backup = backup;

			// Default other state
            Apply = true;
            Override = true;
            OverrideState = PaletteState.Normal;
		}
		#endregion

        #region SetPalettes
        /// <summary>
        /// Update the the primary and backup palettes.
        /// </summary>
        /// <param name="primary">New primary palette.</param>
        /// <param name="backup">New backup palette.</param>
        public void SetPalettes(IPaletteBorder primary,
                                IPaletteBorder backup)
        {
            // Store incoming alternatives
            _primary = primary;
            _backup = backup;
        }
        #endregion
        
        #region Apply
		/// <summary>
		/// Gets and sets a value indicating if override should be applied.
		/// </summary>
		public bool Apply { get; set; }

	    #endregion

        #region Override
        /// <summary>
        /// Gets and sets a value indicating if override state should be applied.
        /// </summary>
        public bool Override { get; set; }

	    #endregion
        
        #region OverrideState
		/// <summary>
		/// Gets and sets the override palette state to use.
		/// </summary>
		public PaletteState OverrideState { get; set; }

	    #endregion

		#region IPaletteBorder
		/// <summary>
		/// Gets a value indicating if border should be drawn.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>InheritBool value.</returns>
		public override InheritBool GetBorderDraw(PaletteState state)
		{
			if (Apply)
			{
                InheritBool ret = _primary.GetBorderDraw(Override ? OverrideState : state);

				if (ret == InheritBool.Inherit)
                {
                    ret = _backup.GetBorderDraw(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderDraw(state);
            }
        }

        /// <summary>
        /// Gets a value indicating which borders to draw.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>PaletteDrawBorders value.</returns>
        public override PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
        {
            if (Apply)
            {
                PaletteDrawBorders ret = _primary.GetBorderDrawBorders(Override ? OverrideState : state);

                if (ret == PaletteDrawBorders.Inherit)
                {
                    ret = _backup.GetBorderDrawBorders(state);
                }

                return ret;
            }
            else
            {
                return _backup.GetBorderDrawBorders(state);
            }
        }

		/// <summary>
		/// Gets the graphics drawing hint.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>PaletteGraphicsHint value.</returns>
		public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
		{
			if (Apply)
			{
                PaletteGraphicsHint ret = _primary.GetBorderGraphicsHint(Override ? OverrideState : state);

				if (ret == PaletteGraphicsHint.Inherit)
                {
                    ret = _backup.GetBorderGraphicsHint(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderGraphicsHint(state);
            }
        }

		/// <summary>
		/// Gets the first border color.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Color value.</returns>
		public override Color GetBorderColor1(PaletteState state)
		{
			if (Apply)
			{
                Color ret = _primary.GetBorderColor1(Override ? OverrideState : state);

				if (ret == Color.Empty)
                {
                    ret = _backup.GetBorderColor1(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderColor1(state);
            }
        }

		/// <summary>
		/// Gets the second border color.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Color value.</returns>
		public override Color GetBorderColor2(PaletteState state)
		{
			if (Apply)
			{
                Color ret = _primary.GetBorderColor2(Override ? OverrideState : state);

				if (ret == Color.Empty)
                {
                    ret = _backup.GetBorderColor2(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderColor2(state);
            }
        }

		/// <summary>
		/// Gets the color drawing style.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Color drawing style.</returns>
		public override PaletteColorStyle GetBorderColorStyle(PaletteState state)
		{
			if (Apply)
			{
                PaletteColorStyle ret = _primary.GetBorderColorStyle(Override ? OverrideState : state);

				if (ret == PaletteColorStyle.Inherit)
                {
                    ret = _backup.GetBorderColorStyle(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderColorStyle(state);
            }
        }

		/// <summary>
		/// Gets the color alignment style.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Color alignment style.</returns>
		public override PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
		{
			if (Apply)
			{
                PaletteRectangleAlign ret = _primary.GetBorderColorAlign(Override ? OverrideState : state);

				if (ret == PaletteRectangleAlign.Inherit)
                {
                    ret = _backup.GetBorderColorAlign(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderColorAlign(state);
            }
        }

		/// <summary>
		/// Gets the color border angle.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Angle used for color drawing.</returns>
		public override float GetBorderColorAngle(PaletteState state)
		{
			if (Apply)
			{
                float ret = _primary.GetBorderColorAngle(Override ? OverrideState : state);

				if (ret == -1f)
                {
                    ret = _backup.GetBorderColorAngle(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderColorAngle(state);
            }
        }

		/// <summary>
		/// Gets the border width.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Border width.</returns>
		public override int GetBorderWidth(PaletteState state)
		{
			if (Apply)
			{
                int ret = _primary.GetBorderWidth(Override ? OverrideState : state);

				if (ret == -1)
                {
                    ret = _backup.GetBorderWidth(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderWidth(state);
            }
        }

		/// <summary>
		/// Gets the border rounding.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Border rounding.</returns>
		public override int GetBorderRounding(PaletteState state)
		{
			if (Apply)
			{
                int ret = _primary.GetBorderRounding(Override ? OverrideState : state);

				if (ret == -1)
                {
                    ret = _backup.GetBorderRounding(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderRounding(state);
            }
        }

		/// <summary>
		/// Gets a border image.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Image instance.</returns>
		public override Image GetBorderImage(PaletteState state)
		{
			if (Apply)
			{
                Image ret = _primary.GetBorderImage(Override ? OverrideState : state) ?? _backup.GetBorderImage(state);

			    return ret;
			}
			else
            {
                return _backup.GetBorderImage(state);
            }
        }

		/// <summary>
		/// Gets the border image style.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Image style value.</returns>
		public override PaletteImageStyle GetBorderImageStyle(PaletteState state)
		{
			if (Apply)
			{
                PaletteImageStyle ret = _primary.GetBorderImageStyle(Override ? OverrideState : state);

				if (ret == PaletteImageStyle.Inherit)
                {
                    ret = _backup.GetBorderImageStyle(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderImageStyle(state);
            }
        }

		/// <summary>
		/// Gets the image alignment style.
		/// </summary>
		/// <param name="state">Palette value should be applicable to this state.</param>
		/// <returns>Image alignment style.</returns>
		public override PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
		{
			if (Apply)
			{
                PaletteRectangleAlign ret = _primary.GetBorderImageAlign(Override ? OverrideState : state);

				if (ret == PaletteRectangleAlign.Inherit)
                {
                    ret = _backup.GetBorderImageAlign(state);
                }

                return ret;
			}
			else
            {
                return _backup.GetBorderImageAlign(state);
            }
        }
        #endregion
	}
}

/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. 
 *     Please see the file LICENSE in this distribution for license terms.
 * Contact: info@trottrax.org
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class BackNumber : ListObject
    {

    }

    public enum BackNoSort
    {
        Default,
        Horse,
        Number,
        Rider
    }

    public enum BackNoFilter
    {
        Horse,
        Number,
        Rider
    }
}

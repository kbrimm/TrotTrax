/* 
 * TrotTrax
 *     Copyright (c) 2015 Katy Brimm
 *     This source file is licensed under the GNU General Public License. Please see the file LICENSE in this distribution for license terms.
 * Contact: kbrimm@pdx.edu
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrotTrax
{
    class TrotTrax
    {
        public static void Main()
        {
            string halt;
            DBDriver dataBase = new DBDriver();

            Console.WriteLine("Press 'enter' to continue...");
            halt = Console.ReadLine();
        }
    }
}

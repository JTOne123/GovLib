#!/usr/bin/env bash

set -e

SCRIPT_PATH="$( cd "$(dirname "$0")" ; pwd -P )"
TEST_DATA_PATH="$SCRIPT_PATH/GovLib.TestData"

rm -r "$TEST_DATA_PATH"

git clone https://github.com/GovLib/GovLib.TestData "$TEST_DATA_PATH"
